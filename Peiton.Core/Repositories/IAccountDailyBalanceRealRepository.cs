using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IAccountDailyBalanceRealRepository : IRepository<AccountDailyBalanceReal>
{
    Task<DailyBalance?> ObtenerBalanceAsync(int accountId, DateTime fecha);
}
