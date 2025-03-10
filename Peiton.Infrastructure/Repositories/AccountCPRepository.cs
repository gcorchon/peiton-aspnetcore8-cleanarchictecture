using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountCPRepository))]
public class AccountCPRepository(PeitonDbContext dbContext) : RepositoryBase<AccountCP>(dbContext), IAccountCPRepository
{
}
