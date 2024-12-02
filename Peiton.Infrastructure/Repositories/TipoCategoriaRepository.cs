using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoCategoriaRepository))]
public class TipoCategoriaRepository(PeitonDbContext dbContext) : RepositoryBase<TipoCategoria>(dbContext), ITipoCategoriaRepository
{
}
