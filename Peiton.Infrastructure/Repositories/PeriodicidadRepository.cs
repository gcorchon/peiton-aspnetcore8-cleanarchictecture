using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPeriodicidadRepository))]
public class PeriodicidadRepository(PeitonDbContext dbContext) : RepositoryBase<Periodicidad>(dbContext), IPeriodicidadRepository
{
}
