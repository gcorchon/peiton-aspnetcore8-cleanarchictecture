using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IControlRendicionRepository : IRepository<ControlRendicion>
{
    Task<ControlRendicion[]> ObtenerControlRendicionesAsync(int tuteladoId);
}
