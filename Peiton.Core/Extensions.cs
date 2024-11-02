using Microsoft.Extensions.DependencyInjection;
using Peiton.Core.Mappings;
using Peiton.DependencyInjection;
using System.Reflection;

namespace Peiton.Core;
public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddInjectable(Assembly.GetExecutingAssembly());

        return services;
    }
}