using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Arrendamientos;

[Injectable]
public class BorrarArrendamientoHandler(IArrendamientoRepository arrendamientoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var arrendamiento = await arrendamientoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Arrendamiento no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(arrendamiento.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        arrendamientoRepository.Remove(arrendamiento);

        await unitOfWork.SaveChangesAsync();
    }
}