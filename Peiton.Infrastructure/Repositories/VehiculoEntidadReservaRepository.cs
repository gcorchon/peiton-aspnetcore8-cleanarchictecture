using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IVehiculoEntidadReservaRepository))]
public class VehiculoEntidadReservaRepository : RepositoryBase<VehiculoEntidadReserva>, IVehiculoEntidadReservaRepository
{
	public VehiculoEntidadReservaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
