using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipologiaProfesionalEntidadGestoraRepository))]
public class TipologiaProfesionalEntidadGestoraRepository : RepositoryBase<TipologiaProfesionalEntidadGestora>, ITipologiaProfesionalEntidadGestoraRepository
{
	public TipologiaProfesionalEntidadGestoraRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
