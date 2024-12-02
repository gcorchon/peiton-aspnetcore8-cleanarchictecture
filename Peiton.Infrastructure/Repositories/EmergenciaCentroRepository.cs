using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEmergenciaCentroRepository))]
public class EmergenciaCentroRepository(PeitonDbContext dbContext) : RepositoryBase<EmergenciaCentro>(dbContext), IEmergenciaCentroRepository
{
}
