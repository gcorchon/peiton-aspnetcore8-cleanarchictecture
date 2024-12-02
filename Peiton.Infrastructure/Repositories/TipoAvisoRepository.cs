using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoAvisoRepository))]
public class TipoAvisoRepository(PeitonDbContext dbContext) : RepositoryBase<TipoAviso>(dbContext), ITipoAvisoRepository
{
}
