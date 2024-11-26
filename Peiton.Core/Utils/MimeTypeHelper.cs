using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.StaticFiles;

namespace Peiton.Core.Utils
{
    public class MimeTypeHelper
    {
        public const string Word = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        public const string Excel = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public const string PDF = "application/pdf";
        public static string GetMimeType(string filePath)
        {
            var provider = new FileExtensionContentTypeProvider();

            // Intenta obtener el tipo MIME correspondiente
            if (!provider.TryGetContentType(filePath, out var mimeType))
            {
                // Si no se encuentra, puedes devolver un tipo MIME por defecto
                mimeType = "application/octet-stream"; // Tipo MIME por defecto
            }

            return mimeType;
        }
    }
}
