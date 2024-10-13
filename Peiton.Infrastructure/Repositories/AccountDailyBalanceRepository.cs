using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountDailyBalanceRepository))]
public class AccountDailyBalanceRepository : RepositoryBase<AccountDailyBalance>, IAccountDailyBalanceRepository
{
	public AccountDailyBalanceRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
