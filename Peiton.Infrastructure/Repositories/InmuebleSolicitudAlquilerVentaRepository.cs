using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInmuebleSolicitudAlquilerVentaRepository))]
	public class InmuebleSolicitudAlquilerVentaRepository: RepositoryBase<InmuebleSolicitudAlquilerVenta>, IInmuebleSolicitudAlquilerVentaRepository
	{
		public InmuebleSolicitudAlquilerVentaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}