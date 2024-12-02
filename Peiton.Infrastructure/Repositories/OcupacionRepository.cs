using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IOcupacionRepository))]
public class OcupacionRepository(PeitonDbContext dbContext) : RepositoryBase<Ocupacion>(dbContext), IOcupacionRepository
{
}
