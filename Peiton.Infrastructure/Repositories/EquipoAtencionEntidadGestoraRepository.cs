using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEquipoAtencionEntidadGestoraRepository))]
public class EquipoAtencionEntidadGestoraRepository : RepositoryBase<EquipoAtencionEntidadGestora>, IEquipoAtencionEntidadGestoraRepository
{
	public EquipoAtencionEntidadGestoraRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
