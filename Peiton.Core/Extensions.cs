using Microsoft.Extensions.DependencyInjection;
using Peiton.ListItems;
using Peiton.DependencyInjection;
using System.Reflection;
using Peiton.Core.Mappings;
using Peiton.Core.Services;
using AutoMapper;

namespace Peiton.Core;
public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(
            (IServiceProvider serviceProvider, IMapperConfigurationExpression mapperConfiguration) =>
                mapperConfiguration.AddProfile(new CajaProfile(serviceProvider.GetService<IIdentityService>()!)),
            Assembly.GetExecutingAssembly()
        );

        services.AddInjectable(Assembly.GetExecutingAssembly());
        services.AddListItemDefinitions(Assembly.GetExecutingAssembly());

        return services;
    }


}