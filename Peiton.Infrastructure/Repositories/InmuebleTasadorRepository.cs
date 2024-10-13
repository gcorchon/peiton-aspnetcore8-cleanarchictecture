using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleTasadorRepository))]
public class InmuebleTasadorRepository : RepositoryBase<InmuebleTasador>, IInmuebleTasadorRepository
{
	public InmuebleTasadorRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
