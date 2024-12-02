using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDistritoRepository))]
public class DistritoRepository(PeitonDbContext dbContext) : RepositoryBase<Distrito>(dbContext), IDistritoRepository
{
}
