using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IControlInventarioRepository : IRepository<ControlInventario>
{
    Task<ControlInventario[]> ObtenerControlInventariosAsync(int tuteladoId);
}
