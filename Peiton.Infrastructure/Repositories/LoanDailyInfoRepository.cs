using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILoanDailyInfoRepository))]
public class LoanDailyInfoRepository(PeitonDbContext dbContext) : RepositoryBase<LoanDailyInfo>(dbContext), ILoanDailyInfoRepository
{
}
