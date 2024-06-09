using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Fondos;

[Injectable]
public class FondosHandler(IAsientoRepository asientoRepository)
{
    public async Task<PaginatedData<FondoListItem>> HandleAsync(FondosFilter filter, IEnumerable<CapituloPartidaFilter> partidaFilter, Pagination pagination)
    {
        var items = await asientoRepository.ObtenerFondoAsync(pagination.Page, pagination.Total, filter, partidaFilter);
        var total = await asientoRepository.ContarFondoAsync(filter, partidaFilter);

        return new PaginatedData<FondoListItem>()
        {
            Items = items,
            Total = total
        };
    }

}