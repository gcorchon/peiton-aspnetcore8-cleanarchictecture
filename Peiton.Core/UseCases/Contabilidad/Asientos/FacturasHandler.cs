using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Asientos;

[Injectable]
public class FacturasHandler(IAsientoRepository asientoRepository)
{    
    public Task<Asiento?> HandleAsync(int id) => asientoRepository.GetByIdAsync(id);    
}