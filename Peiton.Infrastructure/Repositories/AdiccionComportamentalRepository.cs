using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAdiccionComportamentalRepository))]
public class AdiccionComportamentalRepository : RepositoryBase<AdiccionComportamental>, IAdiccionComportamentalRepository
{
	public AdiccionComportamentalRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
