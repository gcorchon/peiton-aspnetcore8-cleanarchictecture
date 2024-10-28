using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ISalaReservaRepository : IRepository<SalaReserva>
{
    Task<SalaReserva[]> ObtenerReservasAsync(DateTime fecha);
}
