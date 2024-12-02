using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFondoSolidarioPeriodicidadRepository))]
public class FondoSolidarioPeriodicidadRepository(PeitonDbContext dbContext) : RepositoryBase<FondoSolidarioPeriodicidad>(dbContext), IFondoSolidarioPeriodicidadRepository
{
}
