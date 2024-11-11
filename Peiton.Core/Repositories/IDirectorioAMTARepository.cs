using Peiton.Contracts.Directorio;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IDirectorioAMTARepository : IRepository<DirectorioAMTA>
{
    Task<DirectorioAMTA[]> ObtenerDirectorioAsync(DirectorioFilter filter);
}
