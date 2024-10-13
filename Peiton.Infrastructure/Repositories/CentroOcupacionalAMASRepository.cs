using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICentroOcupacionalAMASRepository))]
public class CentroOcupacionalAMASRepository : RepositoryBase<CentroOcupacionalAMAS>, ICentroOcupacionalAMASRepository
{
	public CentroOcupacionalAMASRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
