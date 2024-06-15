using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class IncidenciasHandler(ICajaIncidenciaRepository cajaIncidenciaRepository)
{
    public async Task<PaginatedData<CajaIncidencia>> HandleAsync(IncidenciasFilter filter, Pagination pagination)
    {
        var items = await cajaIncidenciaRepository.ObtenerIncidenciasAsync(pagination.Page, pagination.Total, filter);
        var total = await cajaIncidenciaRepository.ContarIncidenciasAsync(filter);

        return new PaginatedData<CajaIncidencia>()
        {
            Items = items,
            Total = total
        };
    }

}
