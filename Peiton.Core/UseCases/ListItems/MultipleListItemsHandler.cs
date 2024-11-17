using Peiton.Contracts.Common;
using Peiton.ListItems;
using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ListItems;

[Injectable]
public class MultipleListItemsHandler(IDbService dbService, IListItemProvider listItemProvider)
{
    public async Task<Dictionary<string, IEnumerable<ListItemExtended>>> HandleAsync(string[] tableNames)
    {
        Dictionary<string, IEnumerable<ListItemExtended>> dict = [];

        foreach (var tableName in tableNames)
        {
            var entityDefinition = listItemProvider.GetDefinition(tableName);
            if (entityDefinition == null) throw new NotFoundException($"Entidad {tableName} no consultable");

            if (entityDefinition.ParentValueColumn == null)
            {
                dict.Add(tableName, await dbService.QueryAsync<ListItemExtended>($"select {entityDefinition.TextColumn} as Text, {entityDefinition.ValueColumn} as Value, null as ParentValue from {tableName} order by 1"));
            }
            else
            {
                dict.Add(tableName, await dbService.QueryAsync<ListItemExtended>($"select {entityDefinition.TextColumn} as Text, {entityDefinition.ValueColumn} as Value,  {entityDefinition.ParentValueColumn} as ParentValue from {tableName} order by 1"));
            }
        }

        return dict;
    }
}