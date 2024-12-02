using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRelacionApoyoInformalRepository))]
public class RelacionApoyoInformalRepository(PeitonDbContext dbContext) : RepositoryBase<RelacionApoyoInformal>(dbContext), IRelacionApoyoInformalRepository
{
}
