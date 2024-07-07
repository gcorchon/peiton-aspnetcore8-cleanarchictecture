using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Asientos;

[Injectable]
public class FacturasHandler(IAsientoRepository asientoRepository)
{
    public async Task<Asiento> HandleAsync(int id)
    {
        var asiento = await asientoRepository.GetByIdAsync(id);
        if (asiento == null) throw new EntityNotFoundException($"No existe el asiento con Id {id}");
        return asiento;
    }
}