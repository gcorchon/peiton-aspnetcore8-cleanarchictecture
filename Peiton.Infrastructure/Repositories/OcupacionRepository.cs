using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IOcupacionRepository))]
public class OcupacionRepository : RepositoryBase<Ocupacion>, IOcupacionRepository
{
	public OcupacionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
