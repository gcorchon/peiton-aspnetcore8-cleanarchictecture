using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IFondoSolidarioFormaPagoRepository))]
	public class FondoSolidarioFormaPagoRepository: RepositoryBase<FondoSolidarioFormaPago>, IFondoSolidarioFormaPagoRepository
	{
		public FondoSolidarioFormaPagoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}