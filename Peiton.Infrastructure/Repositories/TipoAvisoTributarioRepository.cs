using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoAvisoTributarioRepository))]
public class TipoAvisoTributarioRepository : RepositoryBase<TipoAvisoTributario>, ITipoAvisoTributarioRepository
{
	public TipoAvisoTributarioRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
