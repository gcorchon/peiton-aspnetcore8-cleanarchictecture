using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITitularidadServicioEntidadGestoraRepository))]
public class TitularidadServicioEntidadGestoraRepository(PeitonDbContext dbContext) : RepositoryBase<TitularidadServicioEntidadGestora>(dbContext), ITitularidadServicioEntidadGestoraRepository
{
}
