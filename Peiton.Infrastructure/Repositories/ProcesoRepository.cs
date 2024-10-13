using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IProcesoRepository))]
public class ProcesoRepository : RepositoryBase<Proceso>, IProcesoRepository
{
	public ProcesoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
