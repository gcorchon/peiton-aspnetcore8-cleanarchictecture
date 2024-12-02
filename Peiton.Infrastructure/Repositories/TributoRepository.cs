using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITributoRepository))]
public class TributoRepository(PeitonDbContext dbContext) : RepositoryBase<Tributo>(dbContext), ITributoRepository
{
}
