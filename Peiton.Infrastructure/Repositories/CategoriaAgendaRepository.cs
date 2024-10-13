using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaAgendaRepository))]
public class CategoriaAgendaRepository : RepositoryBase<CategoriaAgenda>, ICategoriaAgendaRepository
{
	public CategoriaAgendaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
