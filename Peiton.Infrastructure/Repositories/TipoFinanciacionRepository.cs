using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoFinanciacionRepository))]
	public class TipoFinanciacionRepository: RepositoryBase<TipoFinanciacion>, ITipoFinanciacionRepository
	{
		public TipoFinanciacionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}