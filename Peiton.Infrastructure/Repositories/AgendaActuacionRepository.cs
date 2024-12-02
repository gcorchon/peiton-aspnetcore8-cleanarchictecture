using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgendaActuacionRepository))]
public class AgendaActuacionRepository(PeitonDbContext dbContext) : RepositoryBase<AgendaActuacion>(dbContext), IAgendaActuacionRepository
{
}
