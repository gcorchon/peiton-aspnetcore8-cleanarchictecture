using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Procesos;
using Peiton.Core.Utils;
using Peiton.Core.Exceptions;

namespace Peiton.Core.UseCases.Procesos;

[Injectable]
public class ActualizarProcesoHandler(IProcesoRepository ProcesoRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id, GuardarProcesoRequest request)
    {
        var Proceso = await ProcesoRepository.GetByIdAsync(id);

        if (Proceso == null)
        {
            throw new EntityNotFoundException("Instrucción no encontrada");
        }

        var directory = "App_Data/Procesos";

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

        Proceso.CategoriaProcesoId = request.CategoriaProcesoId;
        Proceso.ContentType = MimeTypeHelper.GetMimeType(filePath);
        Proceso.Descripcion = request.Descripcion;
        Proceso.FileName = fileName;
        Proceso.Fecha = DateTime.Now;

        await unityOfWork.SaveChangesAsync();
    }
}
