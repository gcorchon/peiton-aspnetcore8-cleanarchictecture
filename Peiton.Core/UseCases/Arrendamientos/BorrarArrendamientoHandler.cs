using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Arrendamientos;

[Injectable]
public class BorrarArrendamientoHandler(IArrendamientoRepository arrendamientoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var arrendamiento = await arrendamientoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Arrendamiento no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(arrendamiento.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");
        arrendamientoRepository.Remove(arrendamiento);

        await unitOfWork.SaveChangesAsync();
    }
}