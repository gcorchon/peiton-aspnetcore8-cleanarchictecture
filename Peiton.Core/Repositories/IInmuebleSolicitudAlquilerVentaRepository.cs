using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IInmuebleSolicitudAlquilerVentaRepository : IRepository<InmuebleSolicitudAlquilerVenta>
{
    Task<int> ContarSolicitudesAsync(InmuebleSolicitudesAlquilerVentaFilter filter);
    Task<InmuebleSolicitudAlquilerVenta[]> ObtenerSolicitudesAsync(int page, int total, InmuebleSolicitudesAlquilerVentaFilter filter);
}
