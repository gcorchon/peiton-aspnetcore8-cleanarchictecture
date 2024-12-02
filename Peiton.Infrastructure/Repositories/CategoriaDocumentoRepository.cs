using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaDocumentoRepository))]
public class CategoriaDocumentoRepository(PeitonDbContext dbContext) : RepositoryBase<CategoriaDocumento>(dbContext), ICategoriaDocumentoRepository
{
}
