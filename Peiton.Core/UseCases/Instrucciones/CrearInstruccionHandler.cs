using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Instrucciones;
using Peiton.Core.Entities;
using Peiton.Core.Utils;

namespace Peiton.Core.UseCases.Instrucciones;

[Injectable]
public class CrearInstruccionHandler(IInstruccionRepository instruccionRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(GuardarInstruccionRequest request)
    {
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

        var documento = new Instruccion()
        {
            CategoriaInstruccionId = request.CategoriaInstruccionId,
            ContentType = MimeTypeHelper.GetMimeType(filePath),
            Descripcion = request.Descripcion,
            FileName = fileName,
            Fecha = DateTime.Now
        };

        await instruccionRepository.AddAsync(documento);

        await unitOfWork.SaveChangesAsync();
    }
}
