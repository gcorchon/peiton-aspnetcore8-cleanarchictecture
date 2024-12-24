using System;
using System.IO;
using RazorLight;


namespace Peiton.Infrastructure.Utils;

public class WordTable : IDisposable
{
    private bool _disposed;
    private TextWriter _writer;
    public WordTable(TextWriter writer)
    {
        _writer = writer;
        Begin();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Begin()
    {
        _writer.Write(@"<w:tbl>
                            <w:tblPr>
                                <w:tblStyle w:val=""Tablaconcuadrcula"" />
                                <w:tblW w:w=""0"" w:type=""auto"" />
                                <w:tblLook w:val=""040A"" w:firstRow=""0"" w:lastRow=""0"" w:firstColumn=""0"" w:lastColumn=""0"" w:noHBand=""0"" w:noVBand=""1"" />
                            </w:tblPr>");
    }

    private void End()
    {
        _writer.Write("</w:tbl>");
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            _disposed = true;
            End();
        }
    }

    public void EndTable()
    {
        Dispose(true);
    }
}

