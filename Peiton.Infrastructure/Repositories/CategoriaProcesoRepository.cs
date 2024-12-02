using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaProcesoRepository))]
public class CategoriaProcesoRepository(PeitonDbContext dbContext) : RepositoryBase<CategoriaProceso>(dbContext), ICategoriaProcesoRepository
{
}
