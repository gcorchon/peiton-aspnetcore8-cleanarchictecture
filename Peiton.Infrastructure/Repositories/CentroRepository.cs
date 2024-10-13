using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICentroRepository))]
public class CentroRepository : RepositoryBase<Centro>, ICentroRepository
{
	public CentroRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
