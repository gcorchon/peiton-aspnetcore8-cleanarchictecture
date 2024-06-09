using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IShareRepository))]
	public class ShareRepository: RepositoryBase<Share>, IShareRepository
	{
		public ShareRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}