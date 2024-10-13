using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoAvisoRepository))]
public class TipoAvisoRepository : RepositoryBase<TipoAviso>, ITipoAvisoRepository
{
	public TipoAvisoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
