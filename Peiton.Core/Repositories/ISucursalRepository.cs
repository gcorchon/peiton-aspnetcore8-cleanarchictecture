using Peiton.Contracts.Sucursales;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ISucursalRepository : IRepository<Sucursal>
{
    Task<int> ContarSucursalesAsync(SucursalesFilter filter);
    Task<Sucursal[]> ObtenerSucursalesAsync(int page, int total, SucursalesFilter filter);
    Task<Sucursal?> ObtenerSucursalAsync(int entidadFinancieraId, string oficina);
}
