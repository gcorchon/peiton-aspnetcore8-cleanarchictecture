using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Z.Expressions;

namespace Peiton.Infrastructure.Word
{
    public class WordDocument : IDisposable
    {
        private WordprocessingDocument myDoc;
        private MemoryStream templateStream;
        private Dictionary<OpenXmlPart, XDocument> xdocs;

        private XNamespace nsWPD = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

        private string styles =
@"<w:style w:type=""table"" w:styleId=""Tablaconcuadrcula"">
        <w:name w:val=""Table Grid""/>
        <w:basedOn w:val=""Tablanormal""/>
        <w:uiPriority w:val=""59""/>
        <w:rsid w:val=""00165808""/>
        <w:pPr>
            <w:spacing w:after=""0"" w:line=""240"" w:lineRule=""auto""/>
        </w:pPr>
        <w:tblPr>
            <w:tblBorders>
                <w:top w:val=""single"" w:sz=""4"" w:space=""0"" w:color=""000000"" w:themeColor=""text1""/>
                <w:left w:val=""single"" w:sz=""4"" w:space=""0"" w:color=""000000"" w:themeColor=""text1""/>
                <w:bottom w:val=""single"" w:sz=""4"" w:space=""0"" w:color=""000000"" w:themeColor=""text1""/>
                <w:right w:val=""single"" w:sz=""4"" w:space=""0"" w:color=""000000"" w:themeColor=""text1""/>
                <w:insideH w:val=""single"" w:sz=""4"" w:space=""0"" w:color=""000000"" w:themeColor=""text1""/>
                <w:insideV w:val=""single"" w:sz=""4"" w:space=""0"" w:color=""000000"" w:themeColor=""text1""/>
            </w:tblBorders>
        </w:tblPr>
    </w:style>
    <w:style w:type=""paragraph"" w:styleId=""Ttulo1"">
        <w:name w:val=""heading 1""/>
        <w:basedOn w:val=""Normal""/>
        <w:next w:val=""Normal""/>
        <w:link w:val=""Ttulo1Car""/>
        <w:uiPriority w:val=""9""/>
        <w:qFormat/>
        <w:rsid w:val=""00165808""/>
        <w:pPr>
            <w:keepNext/>
            <w:keepLines/>
            <w:spacing w:before=""480"" w:after=""0""/>
            <w:outlineLvl w:val=""0""/>
        </w:pPr>
        <w:rPr>
            <w:rFonts w:asciiTheme=""majorHAnsi"" w:eastAsiaTheme=""majorEastAsia"" w:hAnsiTheme=""majorHAnsi"" w:cstheme=""majorBidi""/>
            <w:b/>
            <w:bCs/>
            <w:color w:val=""365F91"" w:themeColor=""accent1"" w:themeShade=""BF""/>
            <w:sz w:val=""28""/>
            <w:szCs w:val=""28""/>
        </w:rPr>
    </w:style>
    <w:style w:type=""paragraph"" w:styleId=""Ttulo2"">
        <w:name w:val=""heading 2""/>
        <w:basedOn w:val=""Normal""/>
        <w:next w:val=""Normal""/>
        <w:link w:val=""Ttulo2Car""/>
        <w:uiPriority w:val=""9""/>
        <w:unhideWhenUsed/>
        <w:qFormat/>
        <w:rsid w:val=""00165808""/>
        <w:pPr>
            <w:keepNext/>
            <w:keepLines/>
            <w:spacing w:before=""200"" w:after=""0""/>
            <w:outlineLvl w:val=""1""/>
        </w:pPr>
        <w:rPr>
            <w:rFonts w:asciiTheme=""majorHAnsi"" w:eastAsiaTheme=""majorEastAsia"" w:hAnsiTheme=""majorHAnsi"" w:cstheme=""majorBidi""/>
            <w:b/>
            <w:bCs/>
            <w:color w:val=""4F81BD"" w:themeColor=""accent1""/>
            <w:sz w:val=""26""/>
            <w:szCs w:val=""26""/>
        </w:rPr>
    </w:style>
    <w:style w:type=""paragraph"" w:styleId=""Ttulo3"">
        <w:name w:val=""heading 3""/>
        <w:basedOn w:val=""Normal""/>
        <w:next w:val=""Normal""/>
        <w:link w:val=""Ttulo3Car""/>
        <w:uiPriority w:val=""9""/>
        <w:unhideWhenUsed/>
        <w:qFormat/>
        <w:rsid w:val=""00165808""/>
        <w:pPr>
            <w:keepNext/>
            <w:keepLines/>
            <w:spacing w:before=""200"" w:after=""0""/>
            <w:outlineLvl w:val=""2""/>
        </w:pPr>
        <w:rPr>
            <w:rFonts w:asciiTheme=""majorHAnsi"" w:eastAsiaTheme=""majorEastAsia"" w:hAnsiTheme=""majorHAnsi"" w:cstheme=""majorBidi""/>
            <w:b/>
            <w:bCs/>
            <w:color w:val=""4F81BD"" w:themeColor=""accent1""/>
        </w:rPr>
    </w:style>";

        public WordDocument(string templatePath)
        {
            var resourceStream = File.Open(templatePath, FileMode.Open);

            templateStream = new MemoryStream();
            resourceStream.CopyTo(templateStream);
            resourceStream.Dispose();

            myDoc = WordprocessingDocument.Open(templateStream, true);
            xdocs = new Dictionary<OpenXmlPart, XDocument>();

            xdocs.Add(myDoc.MainDocumentPart!, XDocument.Load(myDoc.MainDocumentPart!.GetStream()));

            foreach (var part in myDoc.MainDocumentPart.HeaderParts)
            {
                xdocs.Add(part, XDocument.Load(part.GetStream()));
            }

            foreach (var part in myDoc.MainDocumentPart.FooterParts)
            {
                xdocs.Add(part, XDocument.Load(part.GetStream()));
            }
        }

        public WordDocument Replace(string search, string value)
        {
            foreach (var xdoc in xdocs.Values)
            {
                foreach (var element in xdoc.Root!.Descendants(nsWPD + "t").Where(t => t.Value.Contains(search)))
                {
                    element.Value = value != null ? element.Value.Replace(search, value) : "";
                }
            }

            return this;
        }

        public WordDocument Replace<T>(T obj) where T : class
        {
            var re = new Regex(@"\{\s*(?<expr>.+?)\s*\}");


            foreach (var xdoc in xdocs.Values)
            {
                foreach (var element in xdoc.Root!.Descendants(nsWPD + "t").Where(t => re.IsMatch(t.Value)))
                {
                    var match = re.Match(element.Value);
                    var expr = match.Groups["expr"].Value;
                    var parts = expr.Split('.');
                    //object current = obj;

                    var current = Eval.Execute<string>("obj." + expr, new { obj });

                    element.Value = current != null ? element.Value.Replace(match.Value, current.ToString()) : "";
                }
            }

            return this;
        }

        public WordDocument Replace(string nodeId, XElement value)
        {
            foreach (var xdoc in xdocs.Values)
            {
                var node = xdoc.Root!.Descendants()
                           .FirstOrDefault(n => n.Attribute("id") != null && n.Attribute("id")!.Value == nodeId);

                if (node != null)
                {
                    node.ReplaceWith(value);
                }
            }

            return this;
        }

        public WordDocument Replace(string search, Action<XElement, int> action)
        {
            int index = 0;
            foreach (var xdoc in xdocs.Values)
            {
                foreach (var element in xdoc.Root!.Descendants(nsWPD + "t").Where(t => t.Value == search).ToList())
                {
                    var paragraph = element.Ancestors(nsWPD + "p").FirstOrDefault();
                    if (paragraph != null)
                    {
                        action(paragraph, index);
                        index++;
                    }
                }
            }
            return this;
        }

        public byte[] Save()
        {
            foreach (var part in xdocs.Keys)
            {
                using (StreamWriter sw = new StreamWriter(part.GetStream(FileMode.Create)))
                {
                    sw.Write(xdocs[part].ToString());
                }
            }

            var stylesPart = myDoc.MainDocumentPart!.StyleDefinitionsPart;
            var stylesDoc = XDocument.Load(myDoc.MainDocumentPart!.StyleDefinitionsPart!.GetStream());

            string wNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

            var tableStyle = stylesDoc.Root!
                             .Elements(XName.Get("style", wNamespace))
                             .FirstOrDefault(x => x.Attribute(XName.Get("styleId", wNamespace))!.Value == "Tablaconcuadrcula");

            if (tableStyle == null)
            {
                var nodo = XElementFromString("<container>" + styles + "</container>");
                stylesDoc.Root.Add(nodo.Elements());
            }

            using (StreamWriter sw = new StreamWriter(stylesPart!.GetStream(FileMode.Create)))
            {
                sw.Write(stylesDoc.ToString());
            }

            return templateStream.ToArray();
        }

        public void Dispose()
        {
            myDoc.Dispose();
            templateStream.Dispose();
        }


        public static XElement XElementFromString(string xml)
        {
            var mngr = new XmlNamespaceManager(new NameTable());
            mngr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            mngr.AddNamespace("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            mngr.AddNamespace("cx", "http://schemas.microsoft.com/office/drawing/2014/chartex");
            mngr.AddNamespace("cx1", "http://schemas.microsoft.com/office/drawing/2015/9/8/chartex");
            mngr.AddNamespace("cx2", "http://schemas.microsoft.com/office/drawing/2015/10/21/chartex");
            mngr.AddNamespace("cx3", "http://schemas.microsoft.com/office/drawing/2016/5/9/chartex");
            mngr.AddNamespace("cx4", "http://schemas.microsoft.com/office/drawing/2016/5/10/chartex");
            mngr.AddNamespace("cx5", "http://schemas.microsoft.com/office/drawing/2016/5/11/chartex");
            mngr.AddNamespace("cx6", "http://schemas.microsoft.com/office/drawing/2016/5/12/chartex");
            mngr.AddNamespace("cx7", "http://schemas.microsoft.com/office/drawing/2016/5/13/chartex");
            mngr.AddNamespace("cx8", "http://schemas.microsoft.com/office/drawing/2016/5/14/chartex");
            mngr.AddNamespace("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            mngr.AddNamespace("aink", "http://schemas.microsoft.com/office/drawing/2016/ink");
            mngr.AddNamespace("am3d", "http://schemas.microsoft.com/office/drawing/2017/model3d");
            mngr.AddNamespace("o", "urn:schemas-microsoft-com:office:office");
            mngr.AddNamespace("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            mngr.AddNamespace("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            mngr.AddNamespace("v", "urn:schemas-microsoft-com:vml");
            mngr.AddNamespace("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            mngr.AddNamespace("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            mngr.AddNamespace("w10", "urn:schemas-microsoft-com:office:word");
            mngr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            mngr.AddNamespace("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            mngr.AddNamespace("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            mngr.AddNamespace("w16cid", "http://schemas.microsoft.com/office/word/2016/wordml/cid");
            mngr.AddNamespace("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
            mngr.AddNamespace("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            mngr.AddNamespace("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            mngr.AddNamespace("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            mngr.AddNamespace("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            var parserContext = new XmlParserContext(null, mngr, null, XmlSpace.None);
            using (var stringReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(stringReader, null, parserContext))
                {
                    return XElement.Load(xmlReader);
                }
            }
        }
    }
}
