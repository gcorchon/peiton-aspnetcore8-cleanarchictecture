using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IVehiculoRepository))]
public class VehiculoRepository : RepositoryBase<Vehiculo>, IVehiculoRepository
{
	public VehiculoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
