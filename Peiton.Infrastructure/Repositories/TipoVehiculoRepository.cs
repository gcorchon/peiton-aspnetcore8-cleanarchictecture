using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoVehiculoRepository))]
public class TipoVehiculoRepository : RepositoryBase<TipoVehiculo>, ITipoVehiculoRepository
{
	public TipoVehiculoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
