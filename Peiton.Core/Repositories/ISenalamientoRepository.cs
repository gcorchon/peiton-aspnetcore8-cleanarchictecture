using Peiton.Contracts.Senalamientos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ISenalamientoRepository : IRepository<Senalamiento>
{
    Task<List<Senalamiento>> ObtenerSenalamientosAsync(SenalamientosFillter filter);
}
