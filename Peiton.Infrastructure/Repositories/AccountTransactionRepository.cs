using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountTransactionRepository))]
public class AccountTransactionRepository : RepositoryBase<AccountTransaction>, IAccountTransactionRepository
{
	public AccountTransactionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
