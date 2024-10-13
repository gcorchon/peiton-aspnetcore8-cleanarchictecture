using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPermisoRepository))]
public class PermisoRepository : RepositoryBase<Permiso>, IPermisoRepository
{
	public PermisoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
