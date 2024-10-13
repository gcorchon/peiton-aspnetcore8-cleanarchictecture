using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUtilizacionOpcionRepository))]
public class UtilizacionOpcionRepository : RepositoryBase<UtilizacionOpcion>, IUtilizacionOpcionRepository
{
	public UtilizacionOpcionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
