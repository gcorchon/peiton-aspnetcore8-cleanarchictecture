using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICredencialCPRepository))]
public class CredencialCPRepository(PeitonDbContext dbContext) : RepositoryBase<CredencialCP>(dbContext), ICredencialCPRepository
{
}
