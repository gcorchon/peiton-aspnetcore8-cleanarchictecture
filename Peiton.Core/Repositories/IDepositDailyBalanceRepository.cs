using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IDepositDailyBalanceRepository : IRepository<DepositDailyBalance>
{
    Task<DailyBalance?> ObtenerBalanceAsync(int id, DateTime fechaCertificado);
}
