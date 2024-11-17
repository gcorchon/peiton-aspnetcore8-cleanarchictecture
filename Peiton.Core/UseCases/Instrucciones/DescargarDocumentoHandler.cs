using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Core.Exceptions;
using Peiton.Contracts.Common;

namespace Peiton.Core.UseCases.Instrucciones;

[Injectable]
public class DescargarDocumentoHandler(IInstruccionRepository instruccionRepository)
{
    public async Task<FileData> HandleAsync(int id)
    {
        var instruccion = await instruccionRepository.GetByIdAsync(id);

        if (instruccion == null)
        {
            throw new NotFoundException("Documento no encontrado");
        }

        var filePath = Path.Combine("App_Data/Instrucciones/{0}", id.ToString(), instruccion.FileName);

        if (!File.Exists(filePath)) throw new NotFoundException("Documento no encontrado");

        return new FileData()
        {
            FileName = Path.GetFileName(filePath),
            Content = await System.IO.File.ReadAllBytesAsync(filePath),
        };
    }
}
