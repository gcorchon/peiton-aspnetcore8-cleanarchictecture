using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IArchivoRepository : IRepository<Archivo>
{
    Task<Archivo[]> ObtenerArchivosAsync(int tuteladoId);
}
