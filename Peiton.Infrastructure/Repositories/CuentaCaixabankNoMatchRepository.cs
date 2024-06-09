using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICuentaCaixabankNoMatchRepository))]
	public class CuentaCaixabankNoMatchRepository: RepositoryBase<CuentaCaixabankNoMatch>, ICuentaCaixabankNoMatchRepository
	{
		public CuentaCaixabankNoMatchRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}