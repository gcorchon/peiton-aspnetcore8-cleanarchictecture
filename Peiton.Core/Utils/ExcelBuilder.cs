using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Peiton.Core.Utils;

public class ExcelBuilder : IDisposable
{
    //private readonly FileStream stream;
    private readonly SpreadsheetDocument spreadsheetDocument;
    private readonly string tempFileName;
    private SheetData? sheetData;
    private Func<object?, Cell>[] cellInfos = [];
    private bool prepareAlreadyCalled = false;

    private readonly WorkbookPart workbookPart;

    private readonly Sheets sheets;

    public ExcelBuilder()
    {
        tempFileName = Path.Combine(Path.GetTempPath(), DateTime.Now.Ticks.ToString() + ".xlsx");
        spreadsheetDocument = SpreadsheetDocument.Create(tempFileName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook);

        workbookPart = spreadsheetDocument.AddWorkbookPart();
        workbookPart.Workbook = new Workbook();
        sheets = workbookPart.Workbook.AppendChild(new Sheets());

        var stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
        stylesPart.Stylesheet = new Stylesheet(
            new Fonts(new Font()),               // Definición de fuentes (vacía en este caso)
            new Fills(new Fill()),               // Definición de rellenos (vacío)
            new Borders(new Border()),           // Definición de bordes (vacío)
            new CellFormats(new CellFormat(), new CellFormat()
            {
                NumberFormatId = 14, // 14 es el ID de formato para fechas en Excel (puedes cambiar este valor para otros tipos de fecha)
                ApplyNumberFormat = true
            })
        );
    }

    public void AddSheet(string name)
    {
        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

        sheetData = new SheetData();
        worksheetPart.Worksheet = new Worksheet(sheetData);

        sheets.AppendChild(new Sheet()
        {
            Id = workbookPart.GetIdOfPart(worksheetPart),
            SheetId = UInt32Value.FromUInt32((uint)sheets.ChildElements.Count + 1),
            Name = name
        });
    }

    public void Prepare(Type[] types)
    {
        var list = new List<Func<object?, Cell>>();

        foreach (var type in types)
        {
            if (type == typeof(string))
            {
                list.Add((o) => new Cell()
                {
                    CellValue = o != null ? new CellValue((string)o) : new CellValue(""),
                    DataType = CellValues.String
                });
            }
            else if (type == typeof(decimal))
            {
                list.Add((o) => new Cell()
                {
                    CellValue = o != null ? new CellValue((decimal)o) : new CellValue(""),
                    DataType = CellValues.Number
                });
            }
            else if (type == typeof(double))
            {
                list.Add((o) => new Cell()
                {
                    CellValue = o != null ? new CellValue((double)o) : new CellValue(""),
                    DataType = CellValues.Number
                });
            }
            else if (type == typeof(DateTime))
            {
                list.Add((o) => new Cell()
                {
                    CellValue = o != null ? new CellValue(((DateTime)o).ToOADate().ToString()) : new CellValue(""),
                    DataType = CellValues.Number,
                    StyleIndex = 1
                });
            }
            else if (type == typeof(bool))
            {
                list.Add((o) => new Cell()
                {
                    CellValue = o != null ? new CellValue((bool)o) : new CellValue(""),
                    DataType = CellValues.Boolean
                });
            }
            else if (type == typeof(int))
            {
                list.Add((o) => new Cell()
                {
                    CellValue = o != null ? new CellValue((int)o) : new CellValue(""),
                    DataType = CellValues.Number
                });
            }
            else
            {
                list.Add((o) => new Cell()
                {
                    CellValue = o != null ? new CellValue(o.ToString() ?? "") : new CellValue(""),
                    DataType = CellValues.String
                });

            }
        }

        this.cellInfos = [.. list];
        prepareAlreadyCalled = true;
    }

    public void AddRow(string[] data)
    {
        if (sheetData == null) throw new Exception("Tienes que añadir al menos un Sheet");

        var row = new Row();
        for (var i = 0; i < data.Length; i++)
        {
            row.Append(
                new Cell() { CellValue = new CellValue(data[i]), DataType = CellValues.String }
            );
        }
        sheetData.AppendChild(row);
    }

    public void AddRow(object?[] data)
    {
        this.AddRows([data]);
    }

    public void AddRows(IEnumerable<object?[]> rows)
    {
        if (!prepareAlreadyCalled) throw new Exception("Tienes que llamar a Prepare antes de llamar a AddRow");
        if (sheetData == null) throw new Exception("Tienes que añadir al menos un Sheet");

        foreach (var data in rows)
        {
            var row = new Row();
            for (var i = 0; i < data.Length; i++)
            {
                row.Append(
                    cellInfos[i](data[i])
                );
            }
            sheetData.AppendChild(row);
        }
    }

    public async Task<byte[]> SaveAsync()
    {
        spreadsheetDocument.Save();
        spreadsheetDocument.Dispose();
        return await File.ReadAllBytesAsync(tempFileName);
    }

    public void Dispose()
    {
        spreadsheetDocument.Dispose();
        File.Delete(tempFileName);
        GC.SuppressFinalize(this);
    }
}