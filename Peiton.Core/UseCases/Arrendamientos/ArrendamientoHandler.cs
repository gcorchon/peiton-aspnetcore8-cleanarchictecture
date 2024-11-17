using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Arrendamientos;

[Injectable]
public class ArrendamientoHandler(IArrendamientoRepository arrendamientoRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<Arrendamiento> HandleAsync(int id)
    {
        var arrendamiento = await arrendamientoRepository.GetByIdAsync(id) ?? throw new NotFoundException("arrendamiento no encontrado");
        if (!await tuteladoRepository.CanViewAsync(arrendamiento.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para ver los datos del tutelado");

        return arrendamiento;
    }
}