using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRazonDenegacionCGJRepository))]
public class RazonDenegacionCGJRepository : RepositoryBase<RazonDenegacionCGJ>, IRazonDenegacionCGJRepository
{
	public RazonDenegacionCGJRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
