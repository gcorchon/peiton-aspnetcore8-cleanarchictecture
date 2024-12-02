using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoFinanciacionRepository))]
public class TipoFinanciacionRepository(PeitonDbContext dbContext) : RepositoryBase<TipoFinanciacion>(dbContext), ITipoFinanciacionRepository
{
}
