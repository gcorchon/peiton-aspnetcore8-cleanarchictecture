using Peiton.Contracts.Procesos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IProcesoRepository : IRepository<Proceso>
{
    Task<List<ProcesoListItem>> ObtenerProcesosAsync();
}
