using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaAgendaRepository))]
public class TareaAgendaRepository(PeitonDbContext dbContext) : RepositoryBase<TareaAgenda>(dbContext), ITareaAgendaRepository
{
}
