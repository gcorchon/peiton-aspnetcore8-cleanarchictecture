using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IPlanDePensionRepository))]
	public class PlanDePensionRepository: RepositoryBase<PlanDePension>, IPlanDePensionRepository
	{
		public PlanDePensionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}