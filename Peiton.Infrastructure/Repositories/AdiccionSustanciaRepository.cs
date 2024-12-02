using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAdiccionSustanciaRepository))]
public class AdiccionSustanciaRepository(PeitonDbContext dbContext) : RepositoryBase<AdiccionSustancia>(dbContext), IAdiccionSustanciaRepository
{
}
