using Peiton.Contracts.Common;
using Peiton.Contracts.Requerimientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Requerimientos;

[Injectable]
public class RequerimientosHandler(IRequerimientoRepository requerimientoRepository)
{
    public async Task<PaginatedData<Requerimiento>> HandleAsync(RequerimientosFilter filter, Pagination pagination)
    {
        var items = await requerimientoRepository.ObtenerRequerimientosAsync(pagination.Page, pagination.Total, filter);
        var total = await requerimientoRepository.ContarRequerimientosAsync(filter);

        return new PaginatedData<Requerimiento>()
        {
            Items = items,
            Total = total
        };
    }
}