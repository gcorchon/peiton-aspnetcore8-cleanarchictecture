using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoCentroRepository))]
public class TipoCentroRepository(PeitonDbContext dbContext) : RepositoryBase<TipoCentro>(dbContext), ITipoCentroRepository
{
}
