using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Vehiculos;

[Injectable]
public class VehiculosHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<Vehiculo[]> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId);
        if (tutelado == null) throw new EntityNotFoundException("Tutelado no encontrado");
        return tutelado.Vehiculos.ToArray();
    }
}