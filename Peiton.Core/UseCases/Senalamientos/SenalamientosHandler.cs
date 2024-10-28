using Peiton.Contracts.Senalamientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Senalamientos;

[Injectable]
public class SenalamientosHandler(ISenalamientoRepository senalamientoRepository)
{
    public async Task<Senalamiento[]> HandleAsync(SenalamientosFillter filter)
    {
        return await senalamientoRepository.ObtenerSenalamientosAsync(filter);
    }
}