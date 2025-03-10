using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUtilizacionOpcionRepository))]
public class UtilizacionOpcionRepository(PeitonDbContext dbContext) : RepositoryBase<UtilizacionOpcion>(dbContext), IUtilizacionOpcionRepository
{
}
