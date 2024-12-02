using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFrecuenciaApoyoInformalRepository))]
public class FrecuenciaApoyoInformalRepository(PeitonDbContext dbContext) : RepositoryBase<FrecuenciaApoyoInformal>(dbContext), IFrecuenciaApoyoInformalRepository
{
}
