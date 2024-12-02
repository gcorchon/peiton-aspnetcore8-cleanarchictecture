using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEquipoAtencionEntidadGestoraRepository))]
public class EquipoAtencionEntidadGestoraRepository(PeitonDbContext dbContext) : RepositoryBase<EquipoAtencionEntidadGestora>(dbContext), IEquipoAtencionEntidadGestoraRepository
{
}
