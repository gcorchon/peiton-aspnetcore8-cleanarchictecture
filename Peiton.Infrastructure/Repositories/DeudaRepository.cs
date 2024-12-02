using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDeudaRepository))]
public class DeudaRepository(PeitonDbContext dbContext) : RepositoryBase<Deuda>(dbContext), IDeudaRepository
{
}
