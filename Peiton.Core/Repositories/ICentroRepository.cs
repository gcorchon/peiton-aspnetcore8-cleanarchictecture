using Peiton.Contracts.Centros;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ICentroRepository : IRepository<Centro>
{
    Task<int> ContarCentrosAsync(CentrosFilter filter);
    Task<Centro[]> ObtenerCentrosAsync(int page, int total, CentrosFilter filter);
}
