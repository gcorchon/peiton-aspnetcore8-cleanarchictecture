using Peiton.Contracts.Requerimientos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IRequerimientoRepository : IRepository<Requerimiento>
{
    Task<int> ContarRequerimientosAsync(RequerimientosFilter filter);
    Task<Requerimiento[]> ObtenerRequerimientosAsync(int page, int total, RequerimientosFilter filter);
}
