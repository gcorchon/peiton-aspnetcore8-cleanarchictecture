using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountCPValidaRepository))]
public class AccountCPValidaRepository(PeitonDbContext dbContext) : RepositoryBase<AccountCPValida>(dbContext), IAccountCPValidaRepository
{
}
