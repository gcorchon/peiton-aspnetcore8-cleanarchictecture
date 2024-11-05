// Variables globales
let zipFile = null;
let modifiedFiles = {}; // Para almacenar el contenido modificado de cada archivo
let currentFilePath = null;
let fileName = null;
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
        const content = await file.async('text');
        const formattedContent = formatXML(modifiedFiles[filePath] || content);
        console.log(formattedContent);
        document.getElementById('fileContent').value = formattedContent;
        currentFilePath = filePath;
    }
}

function formatXML(xml) {
    // Remover espacios en blanco al inicio y al final
    xml = xml.trim();

    // Variables de configuración
    const PADDING = '  '; // Define el tamaño de la indentación
    let formatted = '';   // Almacena el XML formateado
    let indentLevel = 0;  // Nivel de indentación actual

    // Separar las etiquetas de apertura, cierre y auto-cierre en una lista
    xml.split(/>\s*</).forEach((node) => {
        if (node.match(/^\/\w/)) { // Etiqueta de cierre
            indentLevel--;
            formatted += `${PADDING.repeat(indentLevel)}<${node.trim()}>\n`;
        } else if (node.match(/^<?\w/)) { // Etiqueta de apertura o auto-cierre
            formatted += `${PADDING.repeat(indentLevel)}<${node.trim()}>\n`;
            if (!node.match(/\/$/)) { // Si no es una etiqueta de auto-cierre
                indentLevel++;
            }
        } else { // Contenido de texto dentro de una etiqueta
            formatted += `${PADDING.repeat(indentLevel)}${node.trim()}\n`;
        }
    });

    return formatted.trim(); // Elimina espacios en blanco adicionales al final
}

// Guardar el contenido modificado temporalmente
document.getElementById('fileContent').addEventListener('input', () => {
    if (currentFilePath) {
        modifiedFiles[currentFilePath] = document.getElementById('fileContent').value;
    }
});

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
