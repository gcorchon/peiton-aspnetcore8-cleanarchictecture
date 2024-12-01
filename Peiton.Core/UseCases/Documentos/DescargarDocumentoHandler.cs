using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Core.Exceptions;
using Peiton.Contracts.Common;
using Peiton.Core.Utils;

namespace Peiton.Core.UseCases.Documentos;

[Injectable]
public class DescargarDocumentoHandler(IDocumentoRepository documentoRepository)
{
    public async Task<ArchivoViewModel> HandleAsync(int id)
    {
        var documento = await documentoRepository.GetByIdAsync(id);

        if (documento == null)
        {
            throw new NotFoundException("Documento no encontrado");
        }

        var filePath = Path.Combine("App_Data/Documentos/{0}", id.ToString(), documento.FileName);

        if (!File.Exists(filePath)) throw new NotFoundException("Documento no encontrado");

        return new ArchivoViewModel()
        {
            FileName = Path.GetFileName(filePath),
            Data = await System.IO.File.ReadAllBytesAsync(filePath),
            MimeType = documento.ContentType!
        };
    }
}
