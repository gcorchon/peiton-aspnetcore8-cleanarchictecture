using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoRelacionFamiliarRepository))]
public class TipoRelacionFamiliarRepository(PeitonDbContext dbContext) : RepositoryBase<TipoRelacionFamiliar>(dbContext), ITipoRelacionFamiliarRepository
{
}
