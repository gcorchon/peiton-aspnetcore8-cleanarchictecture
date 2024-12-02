using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoCentroDiaRepository))]
public class TipoCentroDiaRepository(PeitonDbContext dbContext) : RepositoryBase<TipoCentroDia>(dbContext), ITipoCentroDiaRepository
{
}
