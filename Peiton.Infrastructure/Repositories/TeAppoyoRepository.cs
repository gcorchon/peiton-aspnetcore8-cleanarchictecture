using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITeAppoyoRepository))]
public class TeAppoyoRepository(PeitonDbContext dbContext) : RepositoryBase<TeAppoyo>(dbContext), ITeAppoyoRepository
{
}
