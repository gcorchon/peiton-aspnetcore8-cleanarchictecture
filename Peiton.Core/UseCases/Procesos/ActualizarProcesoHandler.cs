using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Procesos;
using Peiton.Core.Utils;
using Peiton.Core.Exceptions;

namespace Peiton.Core.UseCases.Procesos;

[Injectable]
public class ActualizarProcesoHandler(IProcesoRepository procesoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, GuardarProcesoRequest request)
    {
        var proceso = await procesoRepository.GetByIdAsync(id);

        if (proceso == null)
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

        proceso.CategoriaProcesoId = request.CategoriaProcesoId;
        proceso.ContentType = MimeTypeHelper.GetMimeType(filePath);
        proceso.Descripcion = request.Descripcion;
        proceso.FileName = fileName;
        proceso.Fecha = DateTime.Now;

        await unitOfWork.SaveChangesAsync();
    }
}
