using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoTitularidadRepository))]
public class TipoTitularidadRepository(PeitonDbContext dbContext) : RepositoryBase<TipoTitularidad>(dbContext), ITipoTitularidadRepository
{
}
