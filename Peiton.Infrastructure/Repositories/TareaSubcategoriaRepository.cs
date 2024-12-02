using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaSubcategoriaRepository))]
public class TareaSubcategoriaRepository(PeitonDbContext dbContext) : RepositoryBase<TareaSubcategoria>(dbContext), ITareaSubcategoriaRepository
{
}
