using Microsoft.Data.SqlClient;
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
        