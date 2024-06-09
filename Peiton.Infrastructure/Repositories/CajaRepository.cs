using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICajaRepository))]
	public class CajaRepository: RepositoryBase<Caja>, ICajaRepository
	{
		public CajaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}