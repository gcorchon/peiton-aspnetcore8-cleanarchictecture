using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoMovimientoCajaRepository))]
public class TipoMovimientoCajaRepository(PeitonDbContext dbContext) : RepositoryBase<TipoMovimientoCaja>(dbContext), ITipoMovimientoCajaRepository
{
}
