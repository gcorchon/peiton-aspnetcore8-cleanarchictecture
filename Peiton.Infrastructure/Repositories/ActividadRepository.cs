using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IActividadRepository))]
public class ActividadRepository(PeitonDbContext dbContext) : RepositoryBase<Actividad>(dbContext), IActividadRepository
{
}
