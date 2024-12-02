using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITablonRepository))]
public class TablonRepository(PeitonDbContext dbContext) : RepositoryBase<Tablon>(dbContext), ITablonRepository
{
}
