using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipologiaActividadEspecializadaRepository))]
public class TipologiaActividadEspecializadaRepository(PeitonDbContext dbContext) : RepositoryBase<TipologiaActividadEspecializada>(dbContext), ITipologiaActividadEspecializadaRepository
{
}
