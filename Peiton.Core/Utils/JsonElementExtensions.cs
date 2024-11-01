using System.Text.Json;

namespace Peiton.Core.Utils;
public static class JsonElementExtensions
{
    public static dynamic ToDynamic(this JsonElement element, IEnumerable<string>? includeOnlyProperties = null)
    {
        var dictionary = new Dictionary<string, object?>();

        foreach (var property in element.EnumerateObject())
        {
            if (includeOnlyProperties != null && !includeOnlyProperties.Contains(property.Name, StringComparer.InvariantCultureIgnoreCase)) continue;
            dictionary[property.Name] = ConvertJsonElement(property.Value);
        }

        return dictionary;
    }

    private static object? ConvertJsonElement(JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                return ToDynamic(element);

            case JsonValueKind.Array:
                var list = new List<object?>();
                foreach (var item in element.EnumerateArray())
                {
                    list.Add(ConvertJsonElement(item));
                }
                return list;

            case JsonValueKind.String:
                return element.GetString();

            case JsonValueKind.Number:
                if (element.TryGetInt32(out int intValue))
                    return intValue;
                if (element.TryGetInt64(out long longValue))
                    return longValue;
                if (element.TryGetDouble(out double doubleValue))
                    return doubleValue;
                return element.GetDecimal(); // Para manejar decimales grandes

            case JsonValueKind.True:
            case JsonValueKind.False:
                return element.GetBoolean();

            case JsonValueKind.Null:
                return null;

            default:
                throw new NotSupportedException($"Tipo JSON no soportado: {element.ValueKind}");
        }
    }
}
