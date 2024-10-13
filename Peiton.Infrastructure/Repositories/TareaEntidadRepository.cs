using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaEntidadRepository))]
public class TareaEntidadRepository : RepositoryBase<TareaEntidad>, ITareaEntidadRepository
{
	public TareaEntidadRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
