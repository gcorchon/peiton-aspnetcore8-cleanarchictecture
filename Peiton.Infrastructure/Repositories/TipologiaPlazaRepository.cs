using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipologiaPlazaRepository))]
public class TipologiaPlazaRepository : RepositoryBase<TipologiaPlaza>, ITipologiaPlazaRepository
{
	public TipologiaPlazaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
