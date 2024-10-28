using Peiton.Contracts.LogAccesos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ILogAccesoRepository : IRepository<LogAcceso>
{
    Task<int> ContarLogAccesosAsync(LogAccesosFilter filter);
    Task<LogAcceso[]> ObtenerLogAccesosAsync(int page, int total, LogAccesosFilter filter);
}
