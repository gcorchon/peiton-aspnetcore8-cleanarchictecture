using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAtencionApoyoFormalRepository))]
public class AtencionApoyoFormalRepository(PeitonDbContext dbContext) : RepositoryBase<AtencionApoyoFormal>(dbContext), IAtencionApoyoFormalRepository
{
}
