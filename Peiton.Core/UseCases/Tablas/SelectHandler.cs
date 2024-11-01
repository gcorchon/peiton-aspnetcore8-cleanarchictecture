
using System.Dynamic;
using Peiton.Contracts.Common;
using Peiton.Contracts.Tablas;
using Peiton.Core.Services;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tablas;

[Injectable]
public class SelectHandler(IDbService dbService)
{
    public async Task<PaginatedData<dynamic>> HandleAsync(string tableName, Pagination pagination, DynamicFilter filter)
    {
        var ignoredKeys = new string[] { "page", "total" };
        var conditions = filter.Keys
                            .Except(ignoredKeys)
                            .Select(k => $"{k} like @{k} ESCAPE N'\\'");

        dynamic queryParams = new ExpandoObject();
        queryParams.startRowIndex = (pagination.Page - 1) * pagination.Total;
        queryParams.totalItems = pagination.Total;

        var queryDic = queryParams as IDictionary<string, object>;
        foreach (var entry in filter)
        {
            if (ignoredKeys.Contains(entry.Key)) continue;
            queryDic!.Add(entry.Key, '%' + entry.Value + '%');
        }

        var where = conditions.Any() ? " where " + string.Join(" and ", conditions) : "";

        var data = await dbService.QueryAsync<dynamic>(@$"SELECT * from {tableName} {where} ORDER BY 1
            OFFSET @startRowIndex ROWS FETCH NEXT @totalItems ROWS ONLY", queryParams);

        var total = await dbService.ExecuteScalarAsync<int>(@$"SELECT count(*) from {tableName} {where}", queryParams);

        return new PaginatedData<dynamic>()
        {
            Total = total,
            Items = data
        };
    }
}