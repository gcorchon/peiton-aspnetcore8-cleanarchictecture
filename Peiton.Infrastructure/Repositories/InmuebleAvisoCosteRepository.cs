using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleAvisoCosteRepository))]
public class InmuebleAvisoCosteRepository : RepositoryBase<InmuebleAvisoCoste>, IInmuebleAvisoCosteRepository
{
	public InmuebleAvisoCosteRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
