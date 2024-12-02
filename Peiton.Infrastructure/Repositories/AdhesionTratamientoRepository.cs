using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAdhesionTratamientoRepository))]
public class AdhesionTratamientoRepository(PeitonDbContext dbContext) : RepositoryBase<AdhesionTratamiento>(dbContext), IAdhesionTratamientoRepository
{
}
