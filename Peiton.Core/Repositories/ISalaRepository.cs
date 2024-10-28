using Peiton.Contracts.Salas;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ISalaRepository : IRepository<Sala>
{
    Task<int> ContarSalasAsync(SalasFilter filter);
    Task<Sala[]> ObtenerSalasAsync(int page, int total, SalasFilter filter);
}
