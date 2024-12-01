using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Core.Utils;
using Peiton.Core.Exceptions;

namespace Peiton.Core.UseCases.Archivos;

[Injectable]
public class BorrarArchivoHandler(IArchivoRepository archivoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var archivo = await archivoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Archivo no encontrado");

        if (!await tuteladoRepository.CanModifyAsync(archivo.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        archivoRepository.Remove(archivo);

        await unitOfWork.SaveChangesAsync();
    }
}
