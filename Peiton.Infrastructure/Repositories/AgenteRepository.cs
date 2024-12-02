using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgenteRepository))]
public class AgenteRepository(PeitonDbContext dbContext) : RepositoryBase<Agente>(dbContext), IAgenteRepository
{
}
