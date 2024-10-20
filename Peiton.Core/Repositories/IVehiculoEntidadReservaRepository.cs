using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IVehiculoEntidadReservaRepository : IRepository<VehiculoEntidadReserva>
{
    Task<List<VehiculoEntidadReserva>> ObtenerReservasAsync(DateTime fecha);
}
