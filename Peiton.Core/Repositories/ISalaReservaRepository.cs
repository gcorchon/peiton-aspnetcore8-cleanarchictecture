using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ISalaReservaRepository : IRepository<SalaReserva>
{
    Task<List<SalaReserva>> ObtenerReservasAsync(DateTime fecha);
}
