using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFundDailyInfoRepository))]
public class FundDailyInfoRepository : RepositoryBase<FundDailyInfo>, IFundDailyInfoRepository
{
	public FundDailyInfoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
