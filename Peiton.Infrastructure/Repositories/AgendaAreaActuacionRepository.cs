using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgendaAreaActuacionRepository))]
public class AgendaAreaActuacionRepository : RepositoryBase<AgendaAreaActuacion>, IAgendaAreaActuacionRepository
{
	public AgendaAreaActuacionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
