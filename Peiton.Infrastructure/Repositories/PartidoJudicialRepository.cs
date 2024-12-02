using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPartidoJudicialRepository))]
public class PartidoJudicialRepository(PeitonDbContext dbContext) : RepositoryBase<PartidoJudicial>(dbContext), IPartidoJudicialRepository
{
}
