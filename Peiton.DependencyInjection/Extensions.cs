using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Peiton.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddInjectable(this IServiceCollection services, Assembly assembly, ServiceLifetime lifetime = ServiceLifetime.Scoped){

        Func<Type, IServiceCollection> add = lifetime switch { ServiceLifetime.Scoped =>  services.AddScoped, 
                                                              ServiceLifetime.Singleton => services.AddSingleton, 
                                                              ServiceLifetime.Transient => services.AddTransient, 
                                                              _ => throw new ArgumentException("Invalid ServiceLifeTime")
                                                              };

        Func<Type, Type, IServiceCollection> add2 = lifetime switch { ServiceLifetime.Scoped =>  services.AddScoped, 
                                                    ServiceLifetime.Singleton => services.AddSingleton, 
                                                    ServiceLifetime.Transient => services.AddTransient, 
                                                    _ => throw new ArgumentException("Invalid ServiceLifeTime")};

        foreach(var injectableType in assembly.GetExportedTypes()){
            var attribute = injectableType.GetCustomAttribute<InjectableAttribute>();
            if( attribute is null) continue;
            if (attribute.InterfaceType is null) {
                add(injectableType);
            } else {
                add2(attribute.InterfaceType, injectableType);
            }
        }
        
        return services;
    }
}
