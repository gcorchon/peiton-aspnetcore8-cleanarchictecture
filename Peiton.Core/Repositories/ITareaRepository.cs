using Peiton.Contracts.Tareas;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ITareaRepository : IRepository<Tarea>
{
    Task<int> ContarTareasAsync(int tuteladoId, TareasFilter filter);
    Task<Tarea[]> ObtenerTareasAsync(int page, int total, int tuteladoId, TareasFilter filter);
}
