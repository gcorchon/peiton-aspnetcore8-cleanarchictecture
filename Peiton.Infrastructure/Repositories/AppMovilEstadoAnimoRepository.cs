using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilEstadoAnimoRepository))]
public class AppMovilEstadoAnimoRepository(PeitonDbContext dbContext) : RepositoryBase<AppMovilEstadoAnimo>(dbContext), IAppMovilEstadoAnimoRepository
{
}
