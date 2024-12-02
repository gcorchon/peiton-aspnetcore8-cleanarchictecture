using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPerfilUsuarioEntidadGestoraRepository))]
public class PerfilUsuarioEntidadGestoraRepository(PeitonDbContext dbContext) : RepositoryBase<PerfilUsuarioEntidadGestora>(dbContext), IPerfilUsuarioEntidadGestoraRepository
{
}
