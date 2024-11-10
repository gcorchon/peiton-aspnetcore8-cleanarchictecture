using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Peiton.ListItems;

public static class Extensions
{
    public static IServiceCollection AddListItemDefinitions(this IServiceCollection services, Assembly assembly)
    {
        IListItemProvider dict = new ListItemProvider();

        foreach (var listItemType in assembly.GetExportedTypes())
        {
            var attribute = listItemType.GetCustomAttribute<ListItemAttribute>();
            if (attribute is null) continue;
            var valueProperty = attribute.Value ?? "Pk_" + listItemType.Name;
            var textProperty = attribute.Text ?? "Descripcion";
            var parentValueProperty = attribute.ParentValue;
            dict.Add(listItemType.Name, new ListItemDefinition(textProperty, valueProperty, parentValueProperty));
        }

        services.AddSingleton(typeof(IListItemProvider), dict);
        return services;
    }


}