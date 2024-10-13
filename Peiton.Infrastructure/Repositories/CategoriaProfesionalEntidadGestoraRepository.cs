using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaProfesionalEntidadGestoraRepository))]
public class CategoriaProfesionalEntidadGestoraRepository : RepositoryBase<CategoriaProfesionalEntidadGestora>, ICategoriaProfesionalEntidadGestoraRepository
{
	public CategoriaProfesionalEntidadGestoraRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
