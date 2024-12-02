using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IGradoApoyoRepository))]
public class GradoApoyoRepository(PeitonDbContext dbContext) : RepositoryBase<GradoApoyo>(dbContext), IGradoApoyoRepository
{
}
