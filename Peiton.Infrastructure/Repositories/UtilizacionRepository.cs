using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUtilizacionRepository))]
public class UtilizacionRepository(PeitonDbContext dbContext) : RepositoryBase<Utilizacion>(dbContext), IUtilizacionRepository
{
}
