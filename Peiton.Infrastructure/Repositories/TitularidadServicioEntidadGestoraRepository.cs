using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITitularidadServicioEntidadGestoraRepository))]
public class TitularidadServicioEntidadGestoraRepository : RepositoryBase<TitularidadServicioEntidadGestora>, ITitularidadServicioEntidadGestoraRepository
{
	public TitularidadServicioEntidadGestoraRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
