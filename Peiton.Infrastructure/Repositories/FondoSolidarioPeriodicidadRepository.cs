using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFondoSolidarioPeriodicidadRepository))]
public class FondoSolidarioPeriodicidadRepository : RepositoryBase<FondoSolidarioPeriodicidad>, IFondoSolidarioPeriodicidadRepository
{
	public FondoSolidarioPeriodicidadRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
