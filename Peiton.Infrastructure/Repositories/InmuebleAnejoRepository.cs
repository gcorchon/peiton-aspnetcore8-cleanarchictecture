using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInmuebleAnejoRepository))]
	public class InmuebleAnejoRepository: RepositoryBase<InmuebleAnejo>, IInmuebleAnejoRepository
	{
		public InmuebleAnejoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}