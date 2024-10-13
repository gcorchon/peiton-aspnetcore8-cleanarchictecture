using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAmbitoRepository))]
public class AmbitoRepository : RepositoryBase<Ambito>, IAmbitoRepository
{
	public AmbitoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
