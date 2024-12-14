using Peiton.Contracts.EscritosSucursales;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IEscritoSucursalRepository : IRepository<EscritoSucursal>
{
    Task<IEnumerable<EscritoSucursalListItem>> ObtenerSucursalesAsync(int tuteladoId);
}
