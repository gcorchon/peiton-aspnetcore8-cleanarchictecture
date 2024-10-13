using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilVoluntarioRepository))]
public class AppMovilVoluntarioRepository : RepositoryBase<AppMovilVoluntario>, IAppMovilVoluntarioRepository
{
	public AppMovilVoluntarioRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
