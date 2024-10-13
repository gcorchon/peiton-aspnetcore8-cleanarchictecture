using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPerfilUsuarioEntidadGestoraRepository))]
public class PerfilUsuarioEntidadGestoraRepository : RepositoryBase<PerfilUsuarioEntidadGestora>, IPerfilUsuarioEntidadGestoraRepository
{
	public PerfilUsuarioEntidadGestoraRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
