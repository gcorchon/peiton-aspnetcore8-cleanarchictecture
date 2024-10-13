using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDistritoRepository))]
public class DistritoRepository : RepositoryBase<Distrito>, IDistritoRepository
{
	public DistritoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
