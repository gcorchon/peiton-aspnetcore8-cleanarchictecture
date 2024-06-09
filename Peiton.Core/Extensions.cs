using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Peiton.Core.Mappings;
using Peiton.DependencyInjection;

namespace Peiton.Core;
public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services){
        
        services.AddAutoMapper(typeof(DomainToViewModelProfile));
        services.AddInjectable(Assembly.GetExecutingAssembly());
        return services;
    }
}