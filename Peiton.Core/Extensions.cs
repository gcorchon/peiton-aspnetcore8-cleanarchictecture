using Microsoft.Extensions.DependencyInjection;
using Peiton.ListItems;
using Peiton.DependencyInjection;
using System.Reflection;
using Peiton.Core.Mappings;
using AutoMapper;

namespace Peiton.Core;
public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(
            (IServiceProvider serviceProvider, IMapperConfigurationExpression mapperConfiguration) => {
                var identityService = serviceProvider.GetService<IIdentityService>()!;
                mapperConfiguration.AddProfile(new CajaProfile(identityService));
                mapperConfiguration.AddProfile(new EmergenciaProfile(identityService));
                mapperConfiguration.AddProfile(new EmergenciaCentroProfile(identityService));
                mapperConfiguration.AddProfile(new AutorizacionProfile(identityService));
                mapperConfiguration.AddProfile(new CitaProfile(identityService));
            },
                
            Assembly.GetExecutingAssembly()
        );

        services.AddInjectable(Assembly.GetExecutingAssembly());
        services.AddListItemDefinitions(Assembly.GetExecutingAssembly());

        return services;
    }


}