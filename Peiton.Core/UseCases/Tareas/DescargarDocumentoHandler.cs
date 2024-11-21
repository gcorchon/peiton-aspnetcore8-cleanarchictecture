
using Peiton.Contracts.Common;
using Peiton.Core.Exceptions;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tareas;

[Injectable]
public class DescargarDocumentoHandler()
{
    public async Task<ArchivoViewModel> HandleAsync(string path)
    {
        var filePath = FilePathValidator.CombineSafe("App_Data/Tareas", path);

        if (!File.Exists(filePath)) throw new NotFoundException("Archivo no encontrado");

        var content = await File.ReadAllBytesAsync(filePath);
        return new ArchivoViewModel()
        {
            Data = content,
            MimeType = MimeTypeHelper.GetMimeType(filePath),
            FileName = path.Substring(path.IndexOf("_") + 1)
        };
    }
}