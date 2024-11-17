using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class DescargarArchivoFondoSolidarioHandler(IFondoSolidarioRepository fondoSolidarioRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<ArchivoFondoSolidario> HandleAsync(int id, int tipo)
    {
        var fondoSolidario = await fondoSolidarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Fondo solidario no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(fondoSolidario.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modifcar datos del tutelado");

        var fileName = tipo switch
        {
            1 => fondoSolidario.Archivo,
            2 => fondoSolidario.Archivo2,
            _ => throw new ArgumentOutOfRangeException("Tipo de archivo no válido")
        };

        if (string.IsNullOrWhiteSpace(fileName)) throw new NotFoundException("Archivo no disponible");

        var filePath = Path.Combine("App_Data/Documentos", fondoSolidario.TuteladoId.ToString(), "fondosolidario", fileName);

        if (!File.Exists(filePath)) throw new NotFoundException("Archivo no encontrado");

        return new ArchivoFondoSolidario()
        {
            Data = await File.ReadAllBytesAsync(filePath),
            FileName = fileName,
            MimeType = MimeTypeHelper.GetMimeType(filePath)
        };
    }
}