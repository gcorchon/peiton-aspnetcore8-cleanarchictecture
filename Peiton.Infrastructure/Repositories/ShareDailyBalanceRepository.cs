using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IShareDailyBalanceRepository))]
public class ShareDailyBalanceRepository : RepositoryBase<ShareDailyBalance>, IShareDailyBalanceRepository
{
	public ShareDailyBalanceRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
