using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class GuardarArchivoFondoSolidarioHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<string> HandleAsync(GuardarArchivoFondoSolidarioRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        var filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + request.Archivo.FileName;
        var directory = Path.Combine("App_Data/Documentos", request.TuteladoId.ToString(), "fondosolidario");

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var filePath = Path.Combine(directory, filename);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.Archivo.CopyToAsync(stream);
        }

        return filename;
    }
}