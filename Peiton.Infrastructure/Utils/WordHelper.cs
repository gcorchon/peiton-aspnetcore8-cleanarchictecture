using System.Text;
using System.Text.RegularExpressions;
using RazorLight;
using RazorLight.Text;

namespace Peiton.Infrastructure.Utils;

public class WordHelper
{

    public static WordTable BeginWordTable(TextWriter writer)
    {
        return new WordTable(writer);
    }


    public static IRawString WordTr(string title, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            return WordTr(
                            new WordTableCell() { Width = 2161, Text = title },
                            new WordTableCell() { Width = 6483, Text = value });
        }
        else
            return new RawString("");
    }

    public static IRawString WordTr(params WordTableCell[] cells)
    {
        return new RawString(
            @"<w:tr>" +
                string.Join("", cells.Select(c => string.Format(@"<w:tc>
                        <w:tcPr>
                            <w:tcW w:w=""{0}"" w:type=""dxa"" />
                        </w:tcPr>
                        <w:p>" +
                        (c.Align != "left" ? string.Format(@"<w:pPr>
                            <w:jc w:val=""{0}"" />
                            </w:pPr>", c.Align) : "")
                        + @"<w:r>
                                <w:t>{1}</w:t>
                            </w:r>
                        </w:p>
                    </w:tc>", c.Width, XmlEncode(c.Text)))) + "</w:tr>");
    }

    public static IRawString WordTitleLevel2(string title)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            return new RawString(string.Format(@"
                        <w:p>
                            <w:pPr>
                            <w:pStyle w:val=""Ttulo2"" />
                            </w:pPr>
                            <w:r>
                            <w:t>{0}</w:t>
                            </w:r>
                        </w:p>", XmlEncode(title)));
        }
        else
            return new RawString("");
    }

    public static IRawString WordTitleLevel3(string title)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            return new RawString(string.Format(@"
                <w:p>
                    <w:pPr>
                    <w:pStyle w:val=""Ttulo3"" />
                    </w:pPr>
                    <w:r>
                    <w:t>{0}</w:t>
                    </w:r>
                </w:p>", XmlEncode(title)));
        }
        else
            return new RawString("");
    }

    public static IRawString WordParagraph(string? text = null)
    {
        if (!string.IsNullOrWhiteSpace(text))
        {
            var lines = Regex.Split(text, @"(?:\r\n|\n)+");
            StringBuilder strb = new StringBuilder();
            foreach (var line in lines)
            {
                strb.AppendFormat(@"
                            <w:p>
                                <w:r>
                                <w:t>{0}</w:t>
                                </w:r>
                            </w:p>", XmlEncode(line));
            }
            return new RawString(strb.ToString());
        }
        else
            return new RawString("");
    }

    public static IRawString WordEmptyParagraph()
    {
        return new RawString(@"<w:p />");
    }

    private static string XmlEncode(string value)
    {
        StringBuilder strb = new StringBuilder(value);

        strb.Replace("&", "&amp;");
        strb.Replace("<", "&lt;");
        strb.Replace(">", "&gt;");
        strb.Replace("\"", "&quot;");
        strb.Replace("'", "&apos;");

        return strb.ToString();
    }

}


