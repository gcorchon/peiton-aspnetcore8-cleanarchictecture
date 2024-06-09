using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInmuebleTipoTitularidadRepository))]
	public class InmuebleTipoTitularidadRepository: RepositoryBase<InmuebleTipoTitularidad>, IInmuebleTipoTitularidadRepository
	{
		public InmuebleTipoTitularidadRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}