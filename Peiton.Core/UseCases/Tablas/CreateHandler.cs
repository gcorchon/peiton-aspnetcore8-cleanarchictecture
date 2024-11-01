using System.Dynamic;
using System.Text.Json;
using Peiton.Core.Services;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tablas;

[Injectable]
public class CreateHandler(IDbService dbService, IDbTableInfoService dbTableInfoService)
{
    public async Task HandleAsync(string tableName, JsonElement data)
    {
        var columnDefinitions = await dbTableInfoService.GetColumnDefinitionsAsync(tableName);
        var readonlyColumns = columnDefinitions.Where(c => c.IsPrimaryKey || c.IsComputed).Select(c => c.ColumnName);

        var keys = data.EnumerateObject().Select(o => o.Name).Except(readonlyColumns);

        var columns = string.Join(", ", keys.Select(k => $"[{k}]"));
        var variables = string.Join(", ", keys.Select(k => $"@{k}"));

        await dbService.ExecuteQueryAsync($"insert into [{tableName}] ({columns}) values({variables})", data.ToDynamic(keys));
    }


}