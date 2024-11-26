using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IShareDailyBalanceRepository : IRepository<ShareDailyBalance>
{
    Task<DailyBalance?> ObtenerBalanceAsync(int id, DateTime fechaCertificado);
}
