using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IFundRepository))]
	public class FundRepository: RepositoryBase<Fund>, IFundRepository
	{
		public FundRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}