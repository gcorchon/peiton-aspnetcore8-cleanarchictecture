using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITributoPeriodicidadRepository))]
public class TributoPeriodicidadRepository(PeitonDbContext dbContext) : RepositoryBase<TributoPeriodicidad>(dbContext), ITributoPeriodicidadRepository
{
}
