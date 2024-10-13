using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITrabajadorSocialRepository))]
public class TrabajadorSocialRepository : RepositoryBase<TrabajadorSocial>, ITrabajadorSocialRepository
{
	public TrabajadorSocialRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
