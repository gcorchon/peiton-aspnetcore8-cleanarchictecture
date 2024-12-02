using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISchoberRepository))]
public class SchoberRepository(PeitonDbContext dbContext) : RepositoryBase<Schober>(dbContext), ISchoberRepository
{
}
