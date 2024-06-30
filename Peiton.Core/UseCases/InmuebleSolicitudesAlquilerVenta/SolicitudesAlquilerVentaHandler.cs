using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InmuebleSolicitudesAlquilerVenta;

[Injectable]
public class SolicitudesAlquilerVentaHandler(IInmuebleSolicitudAlquilerVentaRepository inmuebleSolicitudAlquilerVentaRepository)
{
    public async Task<PaginatedData<InmuebleSolicitudAlquilerVenta>> HandleAsync(InmuebleSolicitudesAlquilerVentaFilter filter, Pagination pagination)
    {
        var items = await inmuebleSolicitudAlquilerVentaRepository.ObtenerSolicitudesAsync(pagination.Page, pagination.Total, filter);
        var total = await inmuebleSolicitudAlquilerVentaRepository.ContarSolicitudesAsync(filter);

        return new PaginatedData<InmuebleSolicitudAlquilerVenta>()
        {
            Items = items,
            Total = total
        };
    }

}
