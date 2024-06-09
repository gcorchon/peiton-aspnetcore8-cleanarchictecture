using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IUrgenciaConceptoCosteRepository))]
	public class UrgenciaConceptoCosteRepository: RepositoryBase<UrgenciaConceptoCoste>, IUrgenciaConceptoCosteRepository
	{
		public UrgenciaConceptoCosteRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}