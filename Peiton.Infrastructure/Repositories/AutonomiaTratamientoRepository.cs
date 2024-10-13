using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAutonomiaTratamientoRepository))]
public class AutonomiaTratamientoRepository : RepositoryBase<AutonomiaTratamiento>, IAutonomiaTratamientoRepository
{
	public AutonomiaTratamientoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
