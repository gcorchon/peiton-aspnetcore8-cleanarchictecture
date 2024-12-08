using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Citas;

[Injectable]
public class CitasHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<Cita[]> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");        
        return [.. tutelado.Citas.OrderByDescending(a => a.Fecha)];
    }
}