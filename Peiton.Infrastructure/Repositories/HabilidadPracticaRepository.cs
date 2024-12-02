using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IHabilidadPracticaRepository))]
public class HabilidadPracticaRepository(PeitonDbContext dbContext) : RepositoryBase<HabilidadPractica>(dbContext), IHabilidadPracticaRepository
{
}
