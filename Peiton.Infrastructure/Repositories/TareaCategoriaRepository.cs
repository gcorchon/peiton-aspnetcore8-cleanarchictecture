using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaCategoriaRepository))]
public class TareaCategoriaRepository(PeitonDbContext dbContext) : RepositoryBase<TareaCategoria>(dbContext), ITareaCategoriaRepository
{
}
