using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAdiccionSustanciaRepository))]
public class AdiccionSustanciaRepository : RepositoryBase<AdiccionSustancia>, IAdiccionSustanciaRepository
{
	public AdiccionSustanciaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
