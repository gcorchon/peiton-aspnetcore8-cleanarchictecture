using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoCGJRepository))]
public class TipoCGJRepository : RepositoryBase<TipoCGJ>, ITipoCGJRepository
{
	public TipoCGJRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
