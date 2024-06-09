using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ILoanRepository))]
	public class LoanRepository: RepositoryBase<Loan>, ILoanRepository
	{
		public LoanRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}