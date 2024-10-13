using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDepositDailyBalanceRepository))]
public class DepositDailyBalanceRepository : RepositoryBase<DepositDailyBalance>, IDepositDailyBalanceRepository
{
	public DepositDailyBalanceRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
