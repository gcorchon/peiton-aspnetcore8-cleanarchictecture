using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IDepositRepository : IRepository<Deposit>
{
    Task<Deposit[]> ObtenerDepositsAsync(int tuteladoId);
}
