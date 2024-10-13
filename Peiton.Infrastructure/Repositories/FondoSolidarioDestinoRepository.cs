using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFondoSolidarioDestinoRepository))]
public class FondoSolidarioDestinoRepository : RepositoryBase<FondoSolidarioDestino>, IFondoSolidarioDestinoRepository
{
	public FondoSolidarioDestinoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
