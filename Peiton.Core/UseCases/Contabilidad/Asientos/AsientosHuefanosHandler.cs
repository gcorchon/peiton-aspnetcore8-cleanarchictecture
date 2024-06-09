
using AutoMapper;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Asientos;

[Injectable]
public class AsientosHuerfanosHandler(IMapper mapper, IAsientoRepository asientoRepository)
{    
    public async Task<PaginatedData<AsientoListItem>> HandleAsync(AsientosHuerfanosFilter filter, Pagination pagination)
    {
        var asientos = await asientoRepository.ObtenerAsientosHuerfanosAsync(pagination.Page, pagination.Total, filter);
        var total = await asientoRepository.ContarAsientosHuerfanosAsync(filter);

        var vm = mapper.Map<IEnumerable<AsientoListItem>>(asientos);

        return new PaginatedData<AsientoListItem>() {
            Items = vm,
            Total = total
        };
    }
}