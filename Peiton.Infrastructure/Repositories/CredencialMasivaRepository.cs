using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICredencialMasivaRepository))]
public class CredencialMasivaRepository : RepositoryBase<CredencialMasiva>, ICredencialMasivaRepository
{
	public CredencialMasivaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
