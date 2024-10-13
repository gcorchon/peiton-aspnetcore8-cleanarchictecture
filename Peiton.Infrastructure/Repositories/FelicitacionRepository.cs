using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFelicitacionRepository))]
public class FelicitacionRepository : RepositoryBase<Felicitacion>, IFelicitacionRepository
{
	public FelicitacionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
