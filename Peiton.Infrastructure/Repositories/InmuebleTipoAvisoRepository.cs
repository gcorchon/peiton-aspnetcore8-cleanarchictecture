using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInmuebleTipoAvisoRepository))]
	public class InmuebleTipoAvisoRepository: RepositoryBase<InmuebleTipoAviso>, IInmuebleTipoAvisoRepository
	{
		public InmuebleTipoAvisoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}