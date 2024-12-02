using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRazonDenegacionCGJRepository))]
public class RazonDenegacionCGJRepository(PeitonDbContext dbContext) : RepositoryBase<RazonDenegacionCGJ>(dbContext), IRazonDenegacionCGJRepository
{
}
