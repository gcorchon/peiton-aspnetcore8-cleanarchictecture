using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRazonIncidenciaCajaRepository))]
public class RazonIncidenciaCajaRepository(PeitonDbContext dbContext) : RepositoryBase<RazonIncidenciaCaja>(dbContext), IRazonIncidenciaCajaRepository
{
}
