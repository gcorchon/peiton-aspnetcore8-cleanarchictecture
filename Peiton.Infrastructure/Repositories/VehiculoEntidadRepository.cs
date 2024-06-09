using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IVehiculoEntidadRepository))]
	public class VehiculoEntidadRepository: RepositoryBase<VehiculoEntidad>, IVehiculoEntidadRepository
	{
		public VehiculoEntidadRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}