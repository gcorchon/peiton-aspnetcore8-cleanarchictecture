using AutoMapper;
using Peiton.Contracts.Arrendamientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Arrendamientos;

[Injectable]
public class CrearArrendamientoHandler(IMapper mapper, IArrendamientoRepository arrendamientoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearArrendamientoRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        var arrendamiento = mapper.Map(request, new Arrendamiento());
        arrendamientoRepository.Add(arrendamiento);
        await unitOfWork.SaveChangesAsync();
    }
}