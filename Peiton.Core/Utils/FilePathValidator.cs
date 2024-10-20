using System;
using System.IO;

namespace Peiton.Core.Utils;  

public class FilePathValidator
{
    public static string CombineSafe(string basePath, string fileName)
    {
        // Combina la ruta base con el nombre del archivo
        var combinedPath = Path.Combine(basePath, fileName);

        // Obtiene la ruta completa normalizada
        var fullPath = Path.GetFullPath(combinedPath);

        // Normaliza la ruta base
        var baseFullPath = Path.GetFullPath(basePath);

        // Verifica si la ruta combinada comienza con la ruta base
        if (!fullPath.StartsWith(baseFullPath, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Acceso no permitido a niveles superiores del sistema de archivos.");
        }

        return fullPath;
    }
}
