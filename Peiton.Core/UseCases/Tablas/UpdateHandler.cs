
using System.Text.Json;
using Peiton.Core.Services;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tablas;

[Injectable]
public class UpdateHandler(IDbService dbService, IDbTableInfoService dbTableInfoService)
{
    public async Task HandleAsync(string tableName, JsonElement data)
    {
        var columnDefinitions = await dbTableInfoService.GetColumnDefinitionsAsync(tableName);
        var readonlyColumns = columnDefinitions.Where(c => c.IsPrimaryKey || c.IsComputed).Select(c => c.ColumnName);
        var primaryKeys = columnDefinitions.Where(c => c.IsPrimaryKey).Select(c => c.ColumnName);

        if (!primaryKeys.Any()) throw new ArgumentException($"La tabla {tableName} no tiene definida ninguna clave primaria");

        var updatableColumns = data.EnumerateObject().Select(o => o.Name).Except(readonlyColumns);

        if (!updatableColumns.Any()) throw new ArgumentException($"No se ha indicado ninguna columna actualizable en La tabla {tableName}");

        var variables = string.Join(", ", updatableColumns.Select(k => $"[{k}]=@{k}"));
        var primaryKeyCondition = string.Join(" and ", primaryKeys.Select(k => $"[{k}]=@{k}"));

        await dbService.ExecuteQueryAsync($"update [{tableName}] set {variables} where {primaryKeyCondition}", data.ToDynamic(updatableColumns.Concat(primaryKeys)));
    }


}