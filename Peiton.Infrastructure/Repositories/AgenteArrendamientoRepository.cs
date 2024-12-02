using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgenteArrendamientoRepository))]
public class AgenteArrendamientoRepository(PeitonDbContext dbContext) : RepositoryBase<AgenteArrendamiento>(dbContext), IAgenteArrendamientoRepository
{
}
