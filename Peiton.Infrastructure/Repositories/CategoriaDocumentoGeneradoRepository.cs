using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaDocumentoGeneradoRepository))]
public class CategoriaDocumentoGeneradoRepository(PeitonDbContext dbContext) : RepositoryBase<CategoriaDocumentoGenerado>(dbContext), ICategoriaDocumentoGeneradoRepository
{
}
