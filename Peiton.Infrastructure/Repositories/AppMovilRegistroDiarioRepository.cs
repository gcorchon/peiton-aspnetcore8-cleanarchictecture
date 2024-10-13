using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilRegistroDiarioRepository))]
public class AppMovilRegistroDiarioRepository : RepositoryBase<AppMovilRegistroDiario>, IAppMovilRegistroDiarioRepository
{
	public AppMovilRegistroDiarioRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
