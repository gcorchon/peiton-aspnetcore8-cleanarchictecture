using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilPatrocinadorRepository))]
public class AppMovilPatrocinadorRepository(PeitonDbContext dbContext) : RepositoryBase<AppMovilPatrocinador>(dbContext), IAppMovilPatrocinadorRepository
{
}
