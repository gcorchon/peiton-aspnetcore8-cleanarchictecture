using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoAnejoRepository))]
public class TipoAnejoRepository : RepositoryBase<TipoAnejo>, ITipoAnejoRepository
{
	public TipoAnejoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
