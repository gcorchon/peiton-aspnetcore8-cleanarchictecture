using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAdiccionComportamentalRepository))]
public class AdiccionComportamentalRepository(PeitonDbContext dbContext) : RepositoryBase<AdiccionComportamental>(dbContext), IAdiccionComportamentalRepository
{
}
