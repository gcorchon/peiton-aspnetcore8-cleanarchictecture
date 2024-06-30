using Peiton.Contracts.Common;
using Peiton.Contracts.MovimientosPendientesCaja;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.CajasAMTA;

[Injectable]
public class MovimientosPendientesCajaHandler(ICajaAMTARepository cajaAMTARepository)
{
    public async Task<PaginatedData<CajaAMTA>> HandleAsync(MovimientosPendientesCajaFilter filter, Pagination pagination)
    {
        var movimientos = await cajaAMTARepository.ObtenerMovimientosPendientesCajaAsync(pagination.Page, pagination.Total, filter);
        var total = await cajaAMTARepository.ContarMovimientosPendientesCajaAsync(filter);

        return new PaginatedData<CajaAMTA>()
        {
            Items = movimientos,
            Total = total
        };
    }
}