using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISeguroAhorroRepository))]
public class SeguroAhorroRepository(PeitonDbContext dbContext) : RepositoryBase<SeguroAhorro>(dbContext), ISeguroAhorroRepository
{
}
