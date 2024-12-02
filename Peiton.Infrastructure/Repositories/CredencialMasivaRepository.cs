using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICredencialMasivaRepository))]
public class CredencialMasivaRepository(PeitonDbContext dbContext) : RepositoryBase<CredencialMasiva>(dbContext), ICredencialMasivaRepository
{
}
