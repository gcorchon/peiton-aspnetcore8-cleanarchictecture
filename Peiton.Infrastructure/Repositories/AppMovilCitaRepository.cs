using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilCitaRepository))]
public class AppMovilCitaRepository(PeitonDbContext dbContext) : RepositoryBase<AppMovilCita>(dbContext), IAppMovilCitaRepository
{
}
