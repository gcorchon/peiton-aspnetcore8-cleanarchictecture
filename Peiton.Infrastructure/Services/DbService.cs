using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Peiton.Contracts.Consultas;
using Peiton.Core.Services;
using Peiton.DependencyInjection;
using System.Data;

namespace Peiton.Infrastructure.Services;

[Injectable(typeof(IDbService))]
public class DbService(PeitonDbContext context) : IDbService
{
    public DataTable DataTable(string sqlQuery, params ParametroConsulta[] parametros)
    {
        return context.DataTable(sqlQuery, parametros.Select(p => new SqlParameter(p.Nombre, p.Valor)).ToArray());
    }

    public T ExecuteScalar<T>(string sqlQuery, params ParametroConsulta[] parametros)
    {
        return context.ExecuteScalar<T>(sqlQuery, parametros.Select(p => new SqlParameter(p.Nombre, p.Valor)).ToArray());
    }

    public Task<IEnumerable<T>> QueryAsync<T>(string sqlQuery, object? queryParams = null)
    {
        return context.Database.GetDbConnection().QueryAsync<T>(sqlQuery, queryParams);
    }

    public Task ExecuteQueryAsync(string sqlQuery, object? queryParams)
    {
        return context.Database.GetDbConnection().ExecuteAsync(sqlQuery, queryParams);
    }
}
