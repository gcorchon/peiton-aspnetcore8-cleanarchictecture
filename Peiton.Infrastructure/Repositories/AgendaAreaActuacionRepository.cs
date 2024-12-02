using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgendaAreaActuacionRepository))]
public class AgendaAreaActuacionRepository(PeitonDbContext dbContext) : RepositoryBase<AgendaAreaActuacion>(dbContext), IAgendaAreaActuacionRepository
{
}
