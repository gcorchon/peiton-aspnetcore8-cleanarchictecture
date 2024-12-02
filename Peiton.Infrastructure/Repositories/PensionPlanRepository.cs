using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPensionPlanRepository))]
public class PensionPlanRepository(PeitonDbContext dbContext) : RepositoryBase<PensionPlan>(dbContext), IPensionPlanRepository
{
}
