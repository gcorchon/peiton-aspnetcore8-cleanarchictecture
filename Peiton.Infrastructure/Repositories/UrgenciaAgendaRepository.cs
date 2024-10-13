using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaAgendaRepository))]
public class UrgenciaAgendaRepository : RepositoryBase<UrgenciaAgenda>, IUrgenciaAgendaRepository
{
	public UrgenciaAgendaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
