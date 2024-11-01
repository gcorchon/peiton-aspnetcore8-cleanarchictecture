
using System.Text.Json;
using Peiton.Core.Services;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tablas;

[Injectable]
public class DeleteHandler(IDbService dbService, IDbTableInfoService dbTableInfoService)
{
    public async Task HandleAsync(string tableName, JsonElement data)
    {
        var columnDefinitions = await dbTableInfoService.GetColumnDefinitionsAsync(tableName);

        var primaryKeys = columnDefinitions.Where(c => c.IsPrimaryKey).Select(c => c.ColumnName);

        if (!primaryKeys.Any()) throw new ArgumentException($"La tabla {tableName} no tiene definida ninguna clave primaria");

        var primaryKeyCondition = string.Join(" and ", primaryKeys.Select(k => $"[{k}]=@{k}"));

        await dbService.ExecuteQueryAsync($"delete from [{tableName}] where {primaryKeyCondition}", data.ToDynamic(primaryKeys));
    }
}