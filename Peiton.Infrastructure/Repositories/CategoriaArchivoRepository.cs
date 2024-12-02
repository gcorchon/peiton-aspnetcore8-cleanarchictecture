using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaArchivoRepository))]
public class CategoriaArchivoRepository(PeitonDbContext dbContext) : RepositoryBase<CategoriaArchivo>(dbContext), ICategoriaArchivoRepository
{
}
