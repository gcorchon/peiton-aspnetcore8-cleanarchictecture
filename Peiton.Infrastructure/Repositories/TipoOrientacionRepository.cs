using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoOrientacionRepository))]
public class TipoOrientacionRepository(PeitonDbContext dbContext) : RepositoryBase<TipoOrientacion>(dbContext), ITipoOrientacionRepository
{
}
