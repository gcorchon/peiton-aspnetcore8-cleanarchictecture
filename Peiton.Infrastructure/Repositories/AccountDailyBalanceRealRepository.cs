using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IAccountDailyBalanceRealRepository))]
	public class AccountDailyBalanceRealRepository: RepositoryBase<AccountDailyBalanceReal>, IAccountDailyBalanceRealRepository
	{
		public AccountDailyBalanceRealRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}