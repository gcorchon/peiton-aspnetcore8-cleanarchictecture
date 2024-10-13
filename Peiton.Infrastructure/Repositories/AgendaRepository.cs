using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgendaRepository))]
public class AgendaRepository : RepositoryBase<Agenda>, IAgendaRepository
{
	public AgendaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
