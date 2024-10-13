using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICodigoEjecucionRepository))]
public class CodigoEjecucionRepository : RepositoryBase<CodigoEjecucion>, ICodigoEjecucionRepository
{
	public CodigoEjecucionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
