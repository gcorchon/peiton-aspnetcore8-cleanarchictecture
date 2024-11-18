using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IShareRepository : IRepository<Share>
{
    Task<Share[]> ObtenerSharesAsync(int tuteladoId);
}
