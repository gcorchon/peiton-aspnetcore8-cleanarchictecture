using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEstadoAprobacionCGJRepository))]
public class EstadoAprobacionCGJRepository(PeitonDbContext dbContext) : RepositoryBase<EstadoAprobacionCGJ>(dbContext), IEstadoAprobacionCGJRepository
{
}
