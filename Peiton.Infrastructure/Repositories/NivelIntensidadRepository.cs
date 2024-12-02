using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(INivelIntensidadRepository))]
public class NivelIntensidadRepository(PeitonDbContext dbContext) : RepositoryBase<NivelIntensidad>(dbContext), INivelIntensidadRepository
{
}
