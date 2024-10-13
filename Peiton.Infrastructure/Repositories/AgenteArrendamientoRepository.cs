using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgenteArrendamientoRepository))]
public class AgenteArrendamientoRepository : RepositoryBase<AgenteArrendamiento>, IAgenteArrendamientoRepository
{
	public AgenteArrendamientoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
