using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Peiton.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddInjectable(this IServiceCollection services, Assembly assembly)
    {
        foreach (var injectableType in assembly.GetExportedTypes())
        {
            var attribute = injectableType.GetCustomAttribute<InjectableAttribute>();
            if (attribute is null) continue;
            if (attribute.InterfaceType is null)
            {
                switch (attribute.Lifetime)
                {
                    case ServiceLifetime.Scoped: services.AddScoped(injectableType); break;
                    case ServiceLifetime.Singleton: services.AddSingleton(injectableType); break;
                    case ServiceLifetime.Transient: services.AddTransient(injectableType); break;
                }
            }
            else
            {
                switch (attribute.Lifetime)
                {
                    case ServiceLifetime.Scoped: services.AddScoped(attribute.InterfaceType, injectableType); break;
                    case ServiceLifetime.Singleton: services.AddSingleton(attribute.InterfaceType, injectableType); break;
                    case ServiceLifetime.Transient: services.AddTransient(attribute.InterfaceType, injectableType); break;
                }
            }
        }

        return services;
    }
}
