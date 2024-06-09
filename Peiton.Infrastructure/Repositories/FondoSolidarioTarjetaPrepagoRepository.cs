using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IFondoSolidarioTarjetaPrepagoRepository))]
	public class FondoSolidarioTarjetaPrepagoRepository: RepositoryBase<FondoSolidarioTarjetaPrepago>, IFondoSolidarioTarjetaPrepagoRepository
	{
		public FondoSolidarioTarjetaPrepagoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}