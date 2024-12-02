using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilPeriodicidadRepository))]
public class AppMovilPeriodicidadRepository(PeitonDbContext dbContext) : RepositoryBase<AppMovilPeriodicidad>(dbContext), IAppMovilPeriodicidadRepository
{
}
