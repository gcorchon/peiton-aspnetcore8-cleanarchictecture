using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
        
        services.AddDbContext<PeitonDbContext>(options =>
                
                options
                    .UseLazyLoadingProxies(true)
                    .UseSqlServer(configuration.GetConnectionString("Peiton"),
                                    opts => opts.UseCompatibilityLevel(120)
                ));

        services.AddInjectable(Assembly.GetExecutingAssembly());

        return services;
    }
}