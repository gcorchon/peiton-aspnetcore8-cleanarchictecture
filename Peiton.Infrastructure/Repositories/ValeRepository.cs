using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IValeRepository))]
	public class ValeRepository: RepositoryBase<Vale>, IValeRepository
	{
		public ValeRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}