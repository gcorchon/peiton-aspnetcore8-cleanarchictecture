using Peiton.Contracts.Consultas;
using System.Data;

namespace Peiton.Core.Services;
public interface IDbService
{
    DataTable DataTable(string sqlQuery, params ParametroConsulta[] parametros);

    T ExecuteScalar<T>(string sqlQuery, params ParametroConsulta[] parametros);

    Task<IEnumerable<T>> QueryAsync<T>(string sqlQuery, object? parametros = null);

    Task ExecuteQueryAsync(string sqlQuery, object? parametros = null);

    Task<T?> ExecuteScalarAsync<T>(string sqlQuery, object? parametros = null);
}
