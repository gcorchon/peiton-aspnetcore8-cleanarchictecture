using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilVoluntarioRepository))]
public class AppMovilVoluntarioRepository(PeitonDbContext dbContext) : RepositoryBase<AppMovilVoluntario>(dbContext), IAppMovilVoluntarioRepository
{
}
