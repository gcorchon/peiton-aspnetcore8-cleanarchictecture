namespace Peiton.ListItems;

public interface IListItemProvider
{
    public void Add(string tableName, ListItemDefinition definition);
    public ListItemDefinition? GetDefinition(string tableName);
}