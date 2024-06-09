using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ISucesionRepository))]
	public class SucesionRepository: RepositoryBase<Sucesion>, ISucesionRepository
	{
		public SucesionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}