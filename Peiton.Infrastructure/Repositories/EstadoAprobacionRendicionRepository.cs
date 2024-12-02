using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEstadoAprobacionRendicionRepository))]
public class EstadoAprobacionRendicionRepository(PeitonDbContext dbContext) : RepositoryBase<EstadoAprobacionRendicion>(dbContext), IEstadoAprobacionRendicionRepository
{
}
