using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IFundDailyInfoRepository : IRepository<FundDailyInfo>
{
    Task<DailyBalance?> ObtenerBalanceAsync(int id, DateTime fechaCertificado);
}
