using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoOrientacionRepository))]
	public class TipoOrientacionRepository: RepositoryBase<TipoOrientacion>, ITipoOrientacionRepository
	{
		public TipoOrientacionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}