using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipologiaPlazaRepository))]
public class TipologiaPlazaRepository(PeitonDbContext dbContext) : RepositoryBase<TipologiaPlaza>(dbContext), ITipologiaPlazaRepository
{
}
