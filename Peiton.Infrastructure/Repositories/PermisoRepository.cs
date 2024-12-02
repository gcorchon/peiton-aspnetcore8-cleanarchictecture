using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPermisoRepository))]
public class PermisoRepository(PeitonDbContext dbContext) : RepositoryBase<Permiso>(dbContext), IPermisoRepository
{
}
