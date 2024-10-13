using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISeguroAhorroRepository))]
public class SeguroAhorroRepository : RepositoryBase<SeguroAhorro>, ISeguroAhorroRepository
{
	public SeguroAhorroRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
