using AutoMapper;

using Peiton.Contracts.Arrendamientos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Arrendamientos;

[Injectable]
public class ActualizarArrendamientoHandler(IMapper mapper, IArrendamientoRepository arrendamientoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ArrendamientoViewModel request)
    {
        var arrendamiento = await arrendamientoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Arrendamiento no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(arrendamiento.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        mapper.Map(request, arrendamiento);

        await unitOfWork.SaveChangesAsync();
    }
}