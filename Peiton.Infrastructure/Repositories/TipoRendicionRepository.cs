using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoRendicionRepository))]
public class TipoRendicionRepository(PeitonDbContext dbContext) : RepositoryBase<TipoRendicion>(dbContext), ITipoRendicionRepository
{
}
