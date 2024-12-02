using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEmergenciaRepository))]
public class EmergenciaRepository(PeitonDbContext dbContext) : RepositoryBase<Emergencia>(dbContext), IEmergenciaRepository
{
}
