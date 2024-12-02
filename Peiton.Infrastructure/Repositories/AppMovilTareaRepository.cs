using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilTareaRepository))]
public class AppMovilTareaRepository(PeitonDbContext dbContext) : RepositoryBase<AppMovilTarea>(dbContext), IAppMovilTareaRepository
{
}
