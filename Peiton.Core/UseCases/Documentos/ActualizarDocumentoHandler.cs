using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Documentos;
using Peiton.Core.Utils;
using Peiton.Core.Exceptions;

namespace Peiton.Core.UseCases.Documentos;

[Injectable]
public class ActualizarDocumentoHandler(IDocumentoRepository DocumentoRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id, GuardarDocumentoRequest request)
    {
        var documento = await DocumentoRepository.GetByIdAsync(id);

        if (documento == null)
        {
            throw new EntityNotFoundException("Documento no encontrado");
        }

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

        documento.CategoriaDocumentoId = request.CategoriaDocumentoId;
        documento.ContentType = MimeTypeHelper.GetMimeType(filePath);
        documento.Descripcion = request.Descripcion;
        documento.FileName = fileName;
        documento.Tags = request.Tags;
        documento.Fecha = DateTime.Now;

        await unityOfWork.SaveChangesAsync();
    }
}
