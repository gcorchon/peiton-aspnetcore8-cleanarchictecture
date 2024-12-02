using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IActividadEspecializadaRepository))]
public class ActividadEspecializadaRepository(PeitonDbContext dbContext) : RepositoryBase<ActividadEspecializada>(dbContext), IActividadEspecializadaRepository
{
}
