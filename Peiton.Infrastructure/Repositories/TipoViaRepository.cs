using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoViaRepository))]
public class TipoViaRepository : RepositoryBase<TipoVia>, ITipoViaRepository
{
	public TipoViaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
