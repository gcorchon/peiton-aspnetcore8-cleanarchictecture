using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IComunidadAutonomaRepository))]
public class ComunidadAutonomaRepository(PeitonDbContext dbContext) : RepositoryBase<ComunidadAutonoma>(dbContext), IComunidadAutonomaRepository
{
}
