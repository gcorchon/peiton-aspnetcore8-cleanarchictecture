using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPlanDePensionRepository))]
public class PlanDePensionRepository(PeitonDbContext dbContext) : RepositoryBase<PlanDePension>(dbContext), IPlanDePensionRepository
{
}
