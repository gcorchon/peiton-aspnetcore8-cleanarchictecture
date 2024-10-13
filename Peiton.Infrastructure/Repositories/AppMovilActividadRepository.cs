using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilActividadRepository))]
public class AppMovilActividadRepository : RepositoryBase<AppMovilActividad>, IAppMovilActividadRepository
{
	public AppMovilActividadRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
