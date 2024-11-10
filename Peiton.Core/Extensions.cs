using Microsoft.Extensions.DependencyInjection;
using Peiton.ListItems;
using Peiton.DependencyInjection;
using System.Reflection;

namespace Peiton.Core;
public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddInjectable(Assembly.GetExecutingAssembly());
        services.AddListItemDefinitions(Assembly.GetExecutingAssembly());

        return services;
    }


}