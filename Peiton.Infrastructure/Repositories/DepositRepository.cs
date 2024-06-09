using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDepositRepository))]
	public class DepositRepository: RepositoryBase<Deposit>, IDepositRepository
	{
		public DepositRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}