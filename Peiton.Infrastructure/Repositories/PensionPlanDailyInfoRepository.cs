using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPensionPlanDailyInfoRepository))]
public class PensionPlanDailyInfoRepository : RepositoryBase<PensionPlanDailyInfo>, IPensionPlanDailyInfoRepository
{
	public PensionPlanDailyInfoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
