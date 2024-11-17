
using Peiton.Contracts.Common;
using Peiton.ListItems;
using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ListItems;

[Injectable]
public class ListItemsHandler(IDbService dbService, IListItemProvider listItemProvider)
{
    public async Task<IEnumerable<ListItem>> HandleAsync(string tableName)
    {
        var entityDefinition = listItemProvider.GetDefinition(tableName);
        if (entityDefinition == null) throw new NotFoundException("Entidad no consultable");
        if (entityDefinition.ParentValueColumn == null)
        {
            return await dbService.QueryAsync<ListItem>($"select {entityDefinition.TextColumn} as Text, {entityDefinition.ValueColumn} as Value from {tableName} order by 1");
        }

        return await dbService.QueryAsync<ListItemExtended>($"select {entityDefinition.TextColumn} as Text, {entityDefinition.ValueColumn} as Value, {entityDefinition.ParentValueColumn} as ParentValue from {tableName} order by 1");
    }
}