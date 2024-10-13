using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgendaActuacionRepository))]
public class AgendaActuacionRepository : RepositoryBase<AgendaActuacion>, IAgendaActuacionRepository
{
	public AgendaActuacionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
