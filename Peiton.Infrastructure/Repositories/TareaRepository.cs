using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaRepository))]
public class TareaRepository : RepositoryBase<Tarea>, ITareaRepository
{
	public TareaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
