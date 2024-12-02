using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAmbitoRepository))]
public class AmbitoRepository(PeitonDbContext dbContext) : RepositoryBase<Ambito>(dbContext), IAmbitoRepository
{
}
