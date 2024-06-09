using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IFondoSolidarioTipoFondoRepository))]
	public class FondoSolidarioTipoFondoRepository: RepositoryBase<FondoSolidarioTipoFondo>, IFondoSolidarioTipoFondoRepository
	{
		public FondoSolidarioTipoFondoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}