using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class CajaAMTAHandler(ICajaAMTARepository cajaAMTARepository)
{
    public async Task<PaginatedData<VwCajaAMTA>> HandleAsync(CajaAMTAFilter filter, Pagination pagination)
    {
        var items = await cajaAMTARepository.ObtenerCajaAMTAAsync(pagination.Page, pagination.Total, 0, filter);
        var total = await cajaAMTARepository.ContarCajaAMTAAsync(0, filter);

        return new PaginatedData<VwCajaAMTA>()
        {
            Items = items,
            Total = total
        };
    }

}
