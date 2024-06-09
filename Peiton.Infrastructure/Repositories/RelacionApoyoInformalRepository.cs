using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IRelacionApoyoInformalRepository))]
	public class RelacionApoyoInformalRepository: RepositoryBase<RelacionApoyoInformal>, IRelacionApoyoInformalRepository
	{
		public RelacionApoyoInformalRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}