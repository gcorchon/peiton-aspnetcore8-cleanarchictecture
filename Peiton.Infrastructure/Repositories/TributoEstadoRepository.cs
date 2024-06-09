using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITributoEstadoRepository))]
	public class TributoEstadoRepository: RepositoryBase<TributoEstado>, ITributoEstadoRepository
	{
		public TributoEstadoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}