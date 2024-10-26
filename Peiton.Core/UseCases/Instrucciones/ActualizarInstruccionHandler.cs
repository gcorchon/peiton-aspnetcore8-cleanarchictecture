using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Instrucciones;
using Peiton.Core.Utils;
using Peiton.Core.Exceptions;

namespace Peiton.Core.UseCases.Instrucciones;

[Injectable]
public class ActualizarInstruccionHandler(IInstruccionRepository instruccionRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, GuardarInstruccionRequest request)
    {
        var instruccion = await instruccionRepository.GetByIdAsync(id);

        if (instruccion == null)
        {
            throw new EntityNotFoundException("Instrucción no encontrada");
        }

        var directory = "App_Data/Instrucciones";

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

        instruccion.CategoriaInstruccionId = request.CategoriaInstruccionId;
        instruccion.ContentType = MimeTypeHelper.GetMimeType(filePath);
        instruccion.Descripcion = request.Descripcion;
        instruccion.FileName = fileName;
        instruccion.Fecha = DateTime.Now;

        await unitOfWork.SaveChangesAsync();
    }
}
