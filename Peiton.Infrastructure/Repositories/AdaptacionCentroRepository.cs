using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAdaptacionCentroRepository))]
public class AdaptacionCentroRepository(PeitonDbContext dbContext) : RepositoryBase<AdaptacionCentro>(dbContext), IAdaptacionCentroRepository
{
}
