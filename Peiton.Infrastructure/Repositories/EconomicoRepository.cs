using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEconomicoRepository))]
public class EconomicoRepository(PeitonDbContext dbContext) : RepositoryBase<Economico>(dbContext), IEconomicoRepository
{
}
