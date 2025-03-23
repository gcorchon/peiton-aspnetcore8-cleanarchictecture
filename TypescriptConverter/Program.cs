using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

class Program
{

    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Uso: MiApp <ruta_assembly> <ruta_salida>");
            return;
        }

        string assemblyPath = args[0];
        string outputPath = args[1];

        if (!File.Exists(assemblyPath))
        {
            Console.WriteLine("El archivo del Assembly no existe.");
            return;
        }

        Assembly assembly = Assembly.LoadFrom(assemblyPath);
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && t.IsPublic)
            .ToArray();

        //Dictionary<string, Entity> typeMappings = types.ToDictionary(t => t.FullName!, t => new Entity(ConvertToKebabCase(t.Name), t.Name));

        foreach (var type in types)
        {
            var typeName = type.Name;

            if (typeName.StartsWith("PaginatedData")) continue;

            string namespacePath = ConvertToKebabCase(type.Namespace!).Replace('.', Path.DirectorySeparatorChar) ?? "";
            string fullPath = Path.Combine(outputPath, namespacePath);

            Directory.CreateDirectory(fullPath);

            string fileName = ConvertToKebabCase(type.Name) + ".ts";
            string filePath = Path.Combine(fullPath, fileName);

            string tsContent = GenerateTypeScriptInterface(type, types);
            File.WriteAllText(filePath, tsContent);
        }

        Console.WriteLine("Conversión completada.");
    }

    static string GenerateTypeScriptInterface(Type type, Type[] assembyTypes)
    {
        StringBuilder sb = new();
        HashSet<Type> imports = [];

        foreach (var prop in type.GetProperties())
        {
            try
            {
                var baseType = GetBaseType(prop.PropertyType);
                if (assembyTypes.Contains(baseType))
                {
                    imports.Add(baseType);
                }                
            }
            catch { }
        }

        foreach (var import in imports)
        {
            var importPath = GetRelativePath(ConvertToKebabCase(type.Namespace!) + "." + type.Name, ConvertToKebabCase(import.Namespace!));
            var fileName = ConvertToKebabCase(import.Name);
            sb.AppendLine($"import {{ {import.Name} }} from '{importPath}/{ fileName }';");
        }

        if (imports.Count > 0)
        {
            sb.AppendLine();
        }
        
        sb.AppendLine($"export interface {type.Name} {{");
        

        foreach (var prop in type.GetProperties())
        {
            string propName = ConvertToCamelCase(prop.Name);
            try
            {
                string propType = MapCSharpTypeToTypeScript(prop.PropertyType, assembyTypes);
                sb.AppendLine($"  {propName}: {propType};");
            }
            catch
            {
                sb.AppendLine($"  {propName}: any;");
            }
        }
        
        sb.AppendLine("}");
        return sb.ToString();
    }

    static string MapCSharpTypeToTypeScript(Type type, Type[] assembyTypes)
    {
        var baseType = GetBaseType(type);
        var isNullable = IsNullable(type);
        var isEnumerable = IsEnumerable(Nullable.GetUnderlyingType(type) ?? type);

        var tsType = "any";
        
        if (baseType == typeof(string)) tsType = "string";
        if (baseType == typeof(int) || baseType == typeof(long) || baseType == typeof(float) || baseType == typeof(double) || baseType == typeof(decimal)) tsType = "number";
        if (baseType == typeof(bool)) tsType = "boolean";
        if (baseType == typeof(DateTime)) tsType = "Date";
        if (assembyTypes.Contains(baseType)) tsType = baseType.Name;

        if (isEnumerable) tsType += "[]";
        if (isNullable) tsType += " | null";
        
        return tsType;
    }

    static string ConvertToCamelCase(string name)
    {
        return char.ToLower(name[0]) + name.Substring(1);
    }

    static string ConvertToKebabCase(string name)
    {
        return Regex.Replace(name, "([a-z])([A-Z])", "$1-$2").ToLower();
    }

    public static bool IsNullable(Type type)
    {
        return Nullable.GetUnderlyingType(type) != null;
    }

    public static Type GetBaseType(Type type)
    {
        var currentType = Nullable.GetUnderlyingType(type) ?? type;
        
        if (typeof(System.Collections.IEnumerable).IsAssignableFrom(currentType) && type != typeof(string))
        {
            Type itemType;

            if (currentType.IsGenericType)
            {
                itemType = currentType.GetGenericArguments()[0];
            }
            else if( currentType.IsArray )
            {
                itemType = currentType.GetElementType()!;
            }
            else
            {
                itemType = typeof(object);
            }

            return itemType;
        }

        return currentType;
    }

    public static bool IsEnumerable(Type type)
    {
        return type.IsArray || (typeof(System.Collections.IEnumerable).IsAssignableFrom(type) && type != typeof(string));
    }

    public static string GetRelativePath(string fromNamespace, string toNamespace)
    {
        var fromParts = fromNamespace.Split('.');
        var toParts = toNamespace.Split('.');

        int commonIndex = 0;
        while (commonIndex < fromParts.Length && commonIndex < toParts.Length && fromParts[commonIndex] == toParts[commonIndex])
        {
            commonIndex++;
        }

        int upLevels = fromParts.Length - commonIndex - 1;
        string upPath = string.Join("/", Enumerable.Repeat("..", upLevels));
        string downPath = string.Join("/", toParts.Skip(commonIndex));

        var path = string.IsNullOrEmpty(upPath) ? downPath : string.IsNullOrEmpty(downPath) ? upPath : upPath + "/" + downPath;
    
        if(path == "") path = ".";
        return path;
    }
}

