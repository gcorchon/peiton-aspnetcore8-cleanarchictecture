using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.CajasAMTA;

[Injectable]
public class CajaAMTAHandler(ICajaAMTARepository cajaAMTARepository)
{
    public async Task<PaginatedData<VwCajaAMTA>> HandleAsync(CajaAMTAFilter filter, Pagination pagination)
    {
        var items = await cajaAMTARepository.ObtenerCajaAMTAAsync(pagination.Page, pagination.Total, filter);
        var total = await cajaAMTARepository.ContarCajaAMTAAsync(filter);

        return new PaginatedData<VwCajaAMTA>()
        {
            Items = items,
            Total = total
        };
    }

}
