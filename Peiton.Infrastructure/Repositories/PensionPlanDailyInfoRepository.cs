using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPensionPlanDailyInfoRepository))]
public class PensionPlanDailyInfoRepository(PeitonDbContext dbContext) : RepositoryBase<PensionPlanDailyInfo>(dbContext), IPensionPlanDailyInfoRepository
{
}
