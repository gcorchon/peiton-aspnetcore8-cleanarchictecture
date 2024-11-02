using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IGrupoRepository : IRepository<Grupo>
{
    Task<Grupo[]> ObtenerGruposConUsuariosAsync();
}
