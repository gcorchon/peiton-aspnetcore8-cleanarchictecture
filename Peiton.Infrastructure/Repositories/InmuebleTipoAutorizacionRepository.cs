using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInmuebleTipoAutorizacionRepository))]
	public class InmuebleTipoAutorizacionRepository: RepositoryBase<InmuebleTipoAutorizacion>, IInmuebleTipoAutorizacionRepository
	{
		public InmuebleTipoAutorizacionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}