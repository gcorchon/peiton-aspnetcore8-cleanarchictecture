using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ISucesionRepository : IRepository<Sucesion>
{
    Task<int> ContarSucesionesAsync(SucesionesFilter filter);
    Task<Sucesion[]> ObtenerSucesionesAsync(int page, int total, SucesionesFilter filter);
}
