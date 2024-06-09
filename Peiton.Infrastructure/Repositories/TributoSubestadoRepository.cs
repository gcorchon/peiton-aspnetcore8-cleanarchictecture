using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITributoSubestadoRepository))]
	public class TributoSubestadoRepository: RepositoryBase<TributoSubestado>, ITributoSubestadoRepository
	{
		public TributoSubestadoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}