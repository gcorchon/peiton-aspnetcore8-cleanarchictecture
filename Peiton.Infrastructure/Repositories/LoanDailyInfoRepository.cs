using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ILoanDailyInfoRepository))]
	public class LoanDailyInfoRepository: RepositoryBase<LoanDailyInfo>, ILoanDailyInfoRepository
	{
		public LoanDailyInfoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}