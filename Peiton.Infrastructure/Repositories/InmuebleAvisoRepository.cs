using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInmuebleAvisoRepository))]
	public class InmuebleAvisoRepository: RepositoryBase<InmuebleAviso>, IInmuebleAvisoRepository
	{
		public InmuebleAvisoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}