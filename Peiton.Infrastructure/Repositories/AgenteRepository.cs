using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgenteRepository))]
public class AgenteRepository : RepositoryBase<Agente>, IAgenteRepository
{
	public AgenteRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
