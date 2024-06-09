using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipologiaApoyoInformalRepository))]
	public class TipologiaApoyoInformalRepository: RepositoryBase<TipologiaApoyoInformal>, ITipologiaApoyoInformalRepository
	{
		public TipologiaApoyoInformalRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}