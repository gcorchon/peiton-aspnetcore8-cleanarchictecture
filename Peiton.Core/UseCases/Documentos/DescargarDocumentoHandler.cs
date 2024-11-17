using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Core.Exceptions;
using Peiton.Contracts.Common;

namespace Peiton.Core.UseCases.Documentos;

[Injectable]
public class DescargarDocumentoHandler(IDocumentoRepository DocumentoRepository)
{
    public async Task<FileData> HandleAsync(int id)
    {
        var documento = await DocumentoRepository.GetByIdAsync(id);

        if (documento == null)
        {
            throw new NotFoundException("Documento no encontrado");
        }

        var filePath = Path.Combine("App_Data/Documentos/{0}", id.ToString(), documento.FileName);

        if (!File.Exists(filePath)) throw new NotFoundException("Documento no encontrado");

        return new FileData()
        {
            FileName = Path.GetFileName(filePath),
            Content = await System.IO.File.ReadAllBytesAsync(filePath),
        };
    }
}
