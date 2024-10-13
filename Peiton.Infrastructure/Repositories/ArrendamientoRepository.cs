using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IArrendamientoRepository))]
public class ArrendamientoRepository : RepositoryBase<Arrendamiento>, IArrendamientoRepository
{
	public ArrendamientoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
