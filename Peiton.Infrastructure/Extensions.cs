using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Peiton.DependencyInjection;
using System.Data.Common;
using System.Data;

namespace Peiton.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<PeitonDbContext>(options =>

                options
                    .UseLazyLoadingProxies(true)
                    .UseSqlServer(configuration.GetConnectionString("Peiton"),
                                    opts => opts.UseCompatibilityLevel(120)
                ));

        services.AddInjectable(Assembly.GetExecutingAssembly());

        return services;
    }

    public static DataTable DataTable(this DbContext context,
           string sqlQuery, params DbParameter[] parameters)
    {
        DataTable dataTable = new DataTable();
        DbConnection connection = context.Database.GetDbConnection();
        DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection)!;
        using (var cmd = dbFactory.CreateCommand())
        {
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlQuery;
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }
            using (DbDataAdapter adapter = dbFactory.CreateDataAdapter()!)
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
        }
        return dataTable;
    }
}