namespace Peiton.ListItems;

public class ListItemProvider : IListItemProvider
{
    private Dictionary<string, ListItemDefinition> dict = [];
    public void Add(string tableName, ListItemDefinition definition)
    {
        this.dict.Add(tableName, definition);
    }

    public ListItemDefinition? GetDefinition(string tableName)
    {
        if (!dict.TryGetValue(tableName, out ListItemDefinition? value)) return null;
        return value;
    }
}