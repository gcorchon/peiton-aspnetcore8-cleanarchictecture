using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Procesos;
using Peiton.Core.Entities;
using Peiton.Core.Utils;

namespace Peiton.Core.UseCases.Procesos;

[Injectable]
public class CrearProcesoHandler(IProcesoRepository procesoRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(GuardarProcesoRequest request)
    {
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

        var proceso = new Proceso()
        {
            CategoriaProcesoId = request.CategoriaProcesoId,
            ContentType = MimeTypeHelper.GetMimeType(filePath),
            Descripcion = request.Descripcion,
            FileName = fileName,
            Fecha = DateTime.Now
        };

        await procesoRepository.AddAsync(proceso);

        await unityOfWork.SaveChangesAsync();
    }
}
