using Peiton.Contracts.Common;
using Peiton.Contracts.Consultas;
using Peiton.Core.Services;
using Peiton.DependencyInjection;
using System.Data;

namespace Peiton.Core.UseCases.GestionMasiva.Consultas;

[Injectable]
public class EjecutarSQLHandler(IDbService dbService)
{
    public Task<EjecutarSQLResponse> HandleAsync(EjecutarSQLRequest request, Pagination pagination)
    {
        var offsetParam = new ParametroConsulta() { Nombre = "@_skip", Valor = (pagination.Page - 1) * pagination.Total };
        var totalParam = new ParametroConsulta() { Nombre = "@_total", Valor = pagination.Total };

        var query = request.Query + "OFFSET @_skip ROWS FETCH NEXT @_total ROWS ONLY";
        var dataTable = dbService.DataTable(query, [.. request.Parameters.ToArray(), offsetParam, totalParam]);
                
        var response = new EjecutarSQLResponse()
        {
            Columns = from DataColumn column in dataTable.Columns
                      select new Column()
                      {
                          Name = column.ColumnName,
                          DataType = column.DataType.Name
                      },
            Rows = from DataRow row in dataTable.Rows
                   select  (from DataColumn column in dataTable.Columns
                           select row[column] == DBNull.Value ? null : row[column]).ToArray()
        };
        
        return Task.FromResult(response);
    }

}