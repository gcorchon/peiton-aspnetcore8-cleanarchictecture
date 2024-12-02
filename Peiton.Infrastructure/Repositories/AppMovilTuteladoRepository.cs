using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilTuteladoRepository))]
public class AppMovilTuteladoRepository(PeitonDbContext dbContext) : RepositoryBase<AppMovilTutelado>(dbContext), IAppMovilTuteladoRepository
{
}
