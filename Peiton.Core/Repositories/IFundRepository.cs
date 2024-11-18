using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IFundRepository : IRepository<Fund>
{
    Task<Fund[]> ObtenerFundsAsync(int tuteladoId);
}
