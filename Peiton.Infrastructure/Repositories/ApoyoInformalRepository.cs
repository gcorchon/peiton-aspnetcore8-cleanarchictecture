using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IApoyoInformalRepository))]
public class ApoyoInformalRepository(PeitonDbContext dbContext) : RepositoryBase<ApoyoInformal>(dbContext), IApoyoInformalRepository
{
}
