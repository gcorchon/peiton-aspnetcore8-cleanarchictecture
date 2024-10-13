using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaProcesoRepository))]
public class CategoriaProcesoRepository : RepositoryBase<CategoriaProceso>, ICategoriaProcesoRepository
{
	public CategoriaProcesoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
