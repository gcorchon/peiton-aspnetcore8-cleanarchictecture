using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaProfesionalEntidadGestoraRepository))]
public class CategoriaProfesionalEntidadGestoraRepository(PeitonDbContext dbContext) : RepositoryBase<CategoriaProfesionalEntidadGestora>(dbContext), ICategoriaProfesionalEntidadGestoraRepository
{
}
