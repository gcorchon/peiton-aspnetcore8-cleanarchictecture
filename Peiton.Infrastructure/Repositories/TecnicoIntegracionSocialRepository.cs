using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITecnicoIntegracionSocialRepository))]
public class TecnicoIntegracionSocialRepository : RepositoryBase<TecnicoIntegracionSocial>, ITecnicoIntegracionSocialRepository
{
	public TecnicoIntegracionSocialRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
