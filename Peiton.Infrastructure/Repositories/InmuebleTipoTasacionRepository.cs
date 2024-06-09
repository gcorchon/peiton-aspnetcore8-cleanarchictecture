using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInmuebleTipoTasacionRepository))]
	public class InmuebleTipoTasacionRepository: RepositoryBase<InmuebleTipoTasacion>, IInmuebleTipoTasacionRepository
	{
		public InmuebleTipoTasacionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}