using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Core.Exceptions;
using Peiton.Contracts.Common;

namespace Peiton.Core.UseCases.Archivos;

[Injectable]
public class DescargarArchivoHandler(IArchivoRepository archivoRepository)
{
    public async Task<ArchivoViewModel> HandleAsync(int id)
    {
        var archivo = await archivoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Archivo no encontrado");
        var filePath = Path.Combine("App_Data/Archivos", archivo.Fecha.ToString("yyyy/MM/dd"), archivo.FileName);

        if (!File.Exists(filePath)) throw new NotFoundException("Archivo no encontrado");

        return new ArchivoViewModel()
        {
            FileName = Path.GetFileName(filePath),
            Data = await File.ReadAllBytesAsync(filePath),
            MimeType = archivo.ContentType
        };
    }
}
