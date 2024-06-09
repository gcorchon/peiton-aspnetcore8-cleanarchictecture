using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IAccountRepository))]
	public class AccountRepository: RepositoryBase<Account>, IAccountRepository
	{
		public AccountRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}