using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleRepository))]
public class InmuebleRepository : RepositoryBase<Inmueble>, IInmuebleRepository
{
	public InmuebleRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
