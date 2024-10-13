using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaEstadoRepository))]
public class TareaEstadoRepository : RepositoryBase<TareaEstado>, ITareaEstadoRepository
{
	public TareaEstadoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
