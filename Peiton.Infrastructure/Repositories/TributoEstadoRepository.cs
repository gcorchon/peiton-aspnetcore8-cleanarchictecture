using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITributoEstadoRepository))]
public class TributoEstadoRepository(PeitonDbContext dbContext) : RepositoryBase<TributoEstado>(dbContext), ITributoEstadoRepository
{
}
