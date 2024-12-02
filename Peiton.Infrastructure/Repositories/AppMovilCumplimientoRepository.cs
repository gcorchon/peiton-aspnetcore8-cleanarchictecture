using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilCumplimientoRepository))]
public class AppMovilCumplimientoRepository(PeitonDbContext dbContext) : RepositoryBase<AppMovilCumplimiento>(dbContext), IAppMovilCumplimientoRepository
{
}
