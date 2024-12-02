using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaAgendaRepository))]
public class UrgenciaAgendaRepository(PeitonDbContext dbContext) : RepositoryBase<UrgenciaAgenda>(dbContext), IUrgenciaAgendaRepository
{
}
