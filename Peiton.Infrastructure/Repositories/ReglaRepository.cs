using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IReglaRepository))]
public class ReglaRepository(PeitonDbContext dbContext) : RepositoryBase<Regla>(dbContext), IReglaRepository
{
}
