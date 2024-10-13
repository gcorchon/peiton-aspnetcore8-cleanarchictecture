using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaAgendaRepository))]
public class TareaAgendaRepository : RepositoryBase<TareaAgenda>, ITareaAgendaRepository
{
	public TareaAgendaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
