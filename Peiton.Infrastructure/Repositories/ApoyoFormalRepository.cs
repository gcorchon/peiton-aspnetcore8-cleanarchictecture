using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IApoyoFormalRepository))]
public class ApoyoFormalRepository : RepositoryBase<ApoyoFormal>, IApoyoFormalRepository
{
	public ApoyoFormalRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
