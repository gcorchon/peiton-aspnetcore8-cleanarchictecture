using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Core.Exceptions;
using Peiton.Contracts.Common;

namespace Peiton.Core.UseCases.Procesos;

[Injectable]
public class DescargarDocumentoHandler(IProcesoRepository procesoRepository)
{
    public async Task<FileData> HandleAsync(int id)
    {
        var proceso = await procesoRepository.GetByIdAsync(id);

        if (proceso == null)
        {
            throw new NotFoundException("Documento no encontrado");
        }

        var filePath = Path.Combine("App_Data/Procesos/{0}", id.ToString(), proceso.FileName);

        if (!File.Exists(filePath)) throw new NotFoundException("Documento no encontrado");

        return new FileData()
        {
            FileName = Path.GetFileName(filePath),
            Content = await System.IO.File.ReadAllBytesAsync(filePath),
        };
    }
}
