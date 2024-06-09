using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IRelacionCentroResidentesRepository))]
	public class RelacionCentroResidentesRepository: RepositoryBase<RelacionCentroResidentes>, IRelacionCentroResidentesRepository
	{
		public RelacionCentroResidentesRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}