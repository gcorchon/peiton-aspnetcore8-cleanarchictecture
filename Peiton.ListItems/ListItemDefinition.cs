namespace Peiton.ListItems;

public class ListItemDefinition
{
    public string TextColumn { get; init; } = null!;
    public string ValueColumn { get; init; } = null!;
    public string? ParentValueColumn { get; init; }
    public ListItemDefinition(string textColumn, string valueColumn, string? parentValueColumn = null)
    {
        this.TextColumn = textColumn;
        this.ValueColumn = valueColumn;
        this.ParentValueColumn = parentValueColumn;
    }
}