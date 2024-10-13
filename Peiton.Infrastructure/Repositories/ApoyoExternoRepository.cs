using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IApoyoExternoRepository))]
public class ApoyoExternoRepository : RepositoryBase<ApoyoExterno>, IApoyoExternoRepository
{
	public ApoyoExternoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
