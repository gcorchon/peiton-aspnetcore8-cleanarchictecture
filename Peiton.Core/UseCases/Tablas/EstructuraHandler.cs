
using Peiton.Contracts.Common;
using Peiton.Contracts.Tablas;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tablas;

[Injectable]
public class EstructuraHandler(IDbService dbService, IDbTableInfoService dbTableInfoService)
{
    public async Task<IEnumerable<TypeScriptTableDefinition>> HandleAsync(string tableName)
    {
        var tableDefinition = await dbTableInfoService.GetColumnDefinitionsAsync(tableName);

        var result = new List<TypeScriptTableDefinition>();

        foreach (var definition in tableDefinition)
        {
            var tsDef = new TypeScriptTableDefinition()
            {
                ColumnName = definition.ColumnName,
                IsComputed = definition.IsComputed,
                IsPrimaryKey = definition.IsPrimaryKey,
                MaxLength = definition.MaxLength,
                TypeScriptType = definition.TypeScriptType,
                ForeignKeyReferencedTable = definition.ForeignKeyReferencedTable
            };

            if (definition.ReferencedTextColumn != null)
            {
                tsDef.Items = await dbService.QueryAsync<ListItem>($"select {definition.ForeignKeyReferencedColumn} as Value, {definition.ReferencedTextColumn} as Text from {definition.ForeignKeyReferencedTable} order by 2");
            }

            result.Add(tsDef);
        }

        return result;
    }
}