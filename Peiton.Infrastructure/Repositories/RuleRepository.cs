using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IRuleRepository))]
	public class RuleRepository: RepositoryBase<Rule>, IRuleRepository
	{
		public RuleRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}