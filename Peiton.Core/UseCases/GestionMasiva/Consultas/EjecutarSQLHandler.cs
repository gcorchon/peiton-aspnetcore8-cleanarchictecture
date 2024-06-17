using Peiton.Contracts.Common;
using Peiton.Contracts.Consultas;
using Peiton.Core.Services;
using Peiton.DependencyInjection;
using System.Data;

namespace Peiton.Core.UseCases.GestionMasiva.Consultas;

[Injectable]
public class EjecutarSQLHandler(IDbService dbService)
{
    public Task<EjecutarSQLResponse> HandleAsync(EjecutarSQLRequest request)
    {
        try
        {
            var query = "set dateformat dmy" + Environment.NewLine + request.Query;
            var dataTable = dbService.DataTable(query, request.Parameters.ToArray());

            var response = new EjecutarSQLResponse()
            {
                Columns = from DataColumn column in dataTable.Columns
                          select new Column()
                          {
                              Name = column.ColumnName,
                              DataType = column.DataType.Name
                          },
                Rows = from DataRow row in dataTable.Rows
                       select (from DataColumn column in dataTable.Columns
                               select row[column] == DBNull.Value ? null : row[column]).ToArray()
            };

            return Task.FromResult(response);
        } 
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

}