using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IApoyoFormalRepository))]
public class ApoyoFormalRepository(PeitonDbContext dbContext) : RepositoryBase<ApoyoFormal>(dbContext), IApoyoFormalRepository
{
}
