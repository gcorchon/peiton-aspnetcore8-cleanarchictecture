using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IOrientacionRepository))]
	public class OrientacionRepository: RepositoryBase<Orientacion>, IOrientacionRepository
	{
		public OrientacionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}