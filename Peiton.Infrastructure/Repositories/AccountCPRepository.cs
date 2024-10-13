using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountCPRepository))]
public class AccountCPRepository : RepositoryBase<AccountCP>, IAccountCPRepository
{
	public AccountCPRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
