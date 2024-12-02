using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEmergenciaLlamadaRepository))]
public class EmergenciaLlamadaRepository(PeitonDbContext dbContext) : RepositoryBase<EmergenciaLlamada>(dbContext), IEmergenciaLlamadaRepository
{
}
