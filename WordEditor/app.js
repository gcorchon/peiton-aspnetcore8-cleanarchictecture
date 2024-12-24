// Variables globales
let zipFile = null;
let modifiedFiles = {}; // Para almacenar el contenido modificado de cada archivo
let currentFilePath = null;
let fileName = null;
let editor = null;


require.config({ paths: { 'vs': 'vs' } });
    
require(['vs/editor/editor.main'], function () {
  // Crear el editor dentro del contenedor
  editor = monaco.editor.create(document.getElementById('editor-container'), {
    value: [
      
    ].join('\n'), // Contenido inicial
    language: 'xml', // Lenguaje del editor
    theme: 'vs-dark', // Tema (vs, vs-dark, hc-black)
    fontSize: 14, // Tamaño de la fuente
    minimap: { enabled: true }, // Habilita la minimapa
    autoIndent: true,
    formatOnPaste: true,
    formatOnType: true
  });

  editor.onDidChangeModelContent((event) => {
    if (currentFilePath) {
        modifiedFiles[currentFilePath] = editor.getValue();
    }
  });
});


// Selección del archivo y carga de su contenido
document.getElementById('fileInput').addEventListener('change', async (event) => {
    const file = event.target.files[0];
    if (file) {
        fileName = file.name;
        zipFile = await JSZip.loadAsync(file);
        displayFileStructure(zipFile);
    }
});

// Mostrar estructura de archivos
function displayFileStructure(zip) {
    const fileStructureDiv = document.getElementById('fileStructure');
    fileStructureDiv.innerHTML = '<h3>Estructura de archivos:</h3>';

    const ul = document.createElement('ul');
    Object.keys(zip.files).forEach(filePath => {
        const li = document.createElement('li');
        li.textContent = filePath;
        li.style.cursor = 'pointer';
        li.addEventListener('click', () => loadFileContent(filePath));
        ul.appendChild(li);
    });
    fileStructureDiv.appendChild(ul);
}

// Cargar contenido del archivo seleccionado
async function loadFileContent(filePath) {
    if (!zipFile) return;

    const file = zipFile.file(filePath);
    if (file) {
        currentFilePath = filePath;
        const content = await file.async('text');       
        const formattedContent = formatXML(modifiedFiles[filePath] || content);
        editor.setValue(formattedContent);
    }
}

function formatXML(xml) {
    const parser = new DOMParser();
    const doc = parser.parseFromString(xml, "application/xml");
    return `<?xml version="1.0" encoding="UTF-8" standalone="yes"?>\n` + recursivePrint(doc.documentElement, 0, '  ');
}

function printOpenNode(node){
    const attrs = [];
    if(!node.attributes) { 
        return node.nodeName;
    }
    for(var i=0;i<node.attributes.length;i++){
        const attr = node.attributes.item(i);
        attrs.push(`${attr.name}="${attr.value}"`);
    }
    if(attrs.length > 0) return node.nodeName + " " + attrs.join(" ");
    return node.nodeName;
    
}
function recursivePrint(node, indentLevel, padding){
    const pad = padding.repeat(indentLevel);
    
    if(node.nodeType == Node.ELEMENT_NODE){
        if(node.childNodes.length == 0) {
            return pad + `<${printOpenNode(node)}/>\n`;
        }
        if(node.childNodes.length == 1 && node.childNodes[0].nodeType == Node.TEXT_NODE) {
            return pad + `<${printOpenNode(node)}>${node.childNodes[0].nodeValue}</${node.nodeName}>\n`;
        }

        let data = pad + `<${printOpenNode(node)}>\n`;
        node.childNodes.forEach(element => {
            data += recursivePrint(element, indentLevel + 1, padding);
        });

        data += pad + `</${node.nodeName}>\n`;
        return data;
    }
    
    
    if(node.childNodes.length == 1 && node.childNodes[0].nodeType == Node.TEXT_NODE) {
        return pad + `<${printOpenNode(node)}>${node.childNodes[0].nodeValue}</${node.nodeName}>\n`;
    }
    
    return '';
}


// Guardar cambios y exportar el documento
document.getElementById('saveChanges').addEventListener('click', async () => {
    if (!zipFile) return;

    // Aplicar todos los cambios en los archivos
    Object.keys(modifiedFiles).forEach(filePath => {
        zipFile.file(filePath, modifiedFiles[filePath]);
    });

    // Generar el nuevo archivo .docx
    const blob = await zipFile.generateAsync({ type: 'blob' });
    saveAs(blob, fileName);
});
