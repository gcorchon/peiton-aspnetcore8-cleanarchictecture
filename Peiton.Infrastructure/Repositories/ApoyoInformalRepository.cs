using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IApoyoInformalRepository))]
public class ApoyoInformalRepository : RepositoryBase<ApoyoInformal>, IApoyoInformalRepository
{
	public ApoyoInformalRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
