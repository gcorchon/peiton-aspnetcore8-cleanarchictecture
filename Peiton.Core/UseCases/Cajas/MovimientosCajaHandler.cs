using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Contracts.Enums;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class MovimientosCajaHandler(ICajaRepository cajaRepository)
{
    public async Task<PaginatedData<Caja>> HandleAsync(TipoMovimiento tipo, CajaFilter filter, Pagination pagination)
    {
        var items = await cajaRepository.ObtenerMovimientosAsync(pagination.Page, pagination.Total, tipo, filter);
        var total = await cajaRepository.ContarMovimientosAsync(tipo, filter);

        return new PaginatedData<Caja>()
        {
            Items = items,
            Total = total
        };
    }

}