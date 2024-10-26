using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Documentos;
using Peiton.Core.Entities;
using Peiton.Core.Utils;

namespace Peiton.Core.UseCases.Documentos;

[Injectable]
public class CrearDocumentoHandler(IDocumentoRepository DocumentoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(GuardarDocumentoRequest request)
    {
        var directory = "App_Data/Documentos";

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var fileName = DateTime.Now.Ticks.ToString() + "_" + request.Archivo.FileName;
        var filePath = Path.Combine(directory, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.Archivo.CopyToAsync(stream);
        }

        var documento = new Documento()
        {
            CategoriaDocumentoId = request.CategoriaDocumentoId,
            ContentType = MimeTypeHelper.GetMimeType(filePath),
            Descripcion = request.Descripcion,
            FileName = fileName,
            Tags = request.Tags,
            Fecha = DateTime.Now
        };

        await DocumentoRepository.AddAsync(documento);

        await unitOfWork.SaveChangesAsync();
    }
}
