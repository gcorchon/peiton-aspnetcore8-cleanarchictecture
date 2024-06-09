using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInmuebleAutorizacionRepository))]
	public class InmuebleAutorizacionRepository: RepositoryBase<InmuebleAutorizacion>, IInmuebleAutorizacionRepository
	{
		public InmuebleAutorizacionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}