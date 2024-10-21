using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Core.Exceptions;
using Peiton.Contracts.Common;

namespace Peiton.Core.UseCases.Procesos;

[Injectable]
public class DescargarDocumentoHandler(IProcesoRepository ProcesoRepository)
{
    public async Task<FileData> HandleAsync(int id)
    {
        var Proceso = await ProcesoRepository.GetByIdAsync(id);

        if (Proceso == null)
        {
            throw new EntityNotFoundException("Documento no encontrado");
        }

        var filePath = Path.Combine("App_Data/Procesos/{0}", id.ToString(), Proceso.FileName);

        if (!File.Exists(filePath)) throw new EntityNotFoundException("Documento no encontrado");

        return new FileData()
        {
            FileName = Path.GetFileName(filePath),
            Content = await System.IO.File.ReadAllBytesAsync(filePath),
        };
    }
}
