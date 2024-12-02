using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilTipoTareaRepository))]
public class AppMovilTipoTareaRepository(PeitonDbContext dbContext) : RepositoryBase<AppMovilTipoTarea>(dbContext), IAppMovilTipoTareaRepository
{
}
