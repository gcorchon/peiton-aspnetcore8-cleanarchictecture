using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFrecuenciaApoyoInformalRepository))]
public class FrecuenciaApoyoInformalRepository : RepositoryBase<FrecuenciaApoyoInformal>, IFrecuenciaApoyoInformalRepository
{
	public FrecuenciaApoyoInformalRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
