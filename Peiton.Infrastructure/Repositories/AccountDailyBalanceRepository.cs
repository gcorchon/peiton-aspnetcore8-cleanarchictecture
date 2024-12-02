using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountDailyBalanceRepository))]
public class AccountDailyBalanceRepository(PeitonDbContext dbContext) : RepositoryBase<AccountDailyBalance>(dbContext), IAccountDailyBalanceRepository
{
}
