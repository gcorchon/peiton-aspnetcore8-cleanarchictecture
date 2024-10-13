using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoMovimientoCajaRepository))]
public class TipoMovimientoCajaRepository : RepositoryBase<TipoMovimientoCaja>, ITipoMovimientoCajaRepository
{
	public TipoMovimientoCajaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
