using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITributoRepository))]
	public class TributoRepository: RepositoryBase<Tributo>, ITributoRepository
	{
		public TributoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}