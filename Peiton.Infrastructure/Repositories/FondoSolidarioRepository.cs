using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IFondoSolidarioRepository))]
	public class FondoSolidarioRepository: RepositoryBase<FondoSolidario>, IFondoSolidarioRepository
	{
		public FondoSolidarioRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}