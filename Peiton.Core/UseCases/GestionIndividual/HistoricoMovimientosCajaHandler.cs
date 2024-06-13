using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionIndividual;

[Injectable]
public class HistoricoMovimientosCajaHandler(ICajaRepository cajaRepository)
{
    public async Task<PaginatedData<Caja>> HandleAsync(int tuteladoId, HistoricoMovimientosFilter filter, Pagination pagination)
    {
        var items = await cajaRepository.ObtenerHistoricoMovimientosAsync(pagination.Page, pagination.Total, tuteladoId, filter);
        var total = await cajaRepository.ContarHistoricoMovimientosAsync(tuteladoId, filter);

        return new PaginatedData<Caja>()
        {
            Items = items,
            Total = total
        };
    }

}
