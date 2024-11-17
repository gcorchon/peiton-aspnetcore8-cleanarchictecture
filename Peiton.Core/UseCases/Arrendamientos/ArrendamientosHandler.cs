using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Arrendamientos;

[Injectable]
public class ArrendamientosHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<Arrendamiento[]> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        return tutelado.Arrendamientos.ToArray();
    }
}