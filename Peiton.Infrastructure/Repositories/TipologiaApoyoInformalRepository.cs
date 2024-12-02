using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipologiaApoyoInformalRepository))]
public class TipologiaApoyoInformalRepository(PeitonDbContext dbContext) : RepositoryBase<TipologiaApoyoInformal>(dbContext), ITipologiaApoyoInformalRepository
{
}
