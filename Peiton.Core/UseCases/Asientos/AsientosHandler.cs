
using AutoMapper;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Asientos;

[Injectable]
public class AsientosHandler(IMapper mapper, IAsientoRepository asientoRepository)
{
    public async Task<PaginatedData<AsientoListItem>> HandleAsync(AsientosFilter filter, Pagination pagination)
    {
        var asientos = await asientoRepository.ObtenerAsientosAsync(pagination.Page, pagination.Total, filter);
        var total = await asientoRepository.ContarAsientosAsync(filter);

        var vm = mapper.Map<IEnumerable<AsientoListItem>>(asientos);

        return new PaginatedData<AsientoListItem>()
        {
            Items = vm,
            Total = total
        };
    }
}