namespace Peiton.Contracts.Tablas;

public class ColumnDefinition
{
    public string ColumnName { get; set; } = null!;
    public string SqlType { get; set; } = null!;
    public int? MaxLength { get; set; }
    public bool IsPrimaryKey { get; set; }
    public string TypeScriptType { get; set; } = null!;
    public bool IsComputed { get; set; }
    public string? ForeignKeyReferencedTable { get; set; }
    public string? ForeignKeyReferencedColumn { get; set; }
    public string? ReferencedTextColumn { get; set; }
}