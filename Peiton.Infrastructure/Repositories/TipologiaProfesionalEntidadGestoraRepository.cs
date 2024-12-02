using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipologiaProfesionalEntidadGestoraRepository))]
public class TipologiaProfesionalEntidadGestoraRepository(PeitonDbContext dbContext) : RepositoryBase<TipologiaProfesionalEntidadGestora>(dbContext), ITipologiaProfesionalEntidadGestoraRepository
{
}
