using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPartidoJudicialInhibicionRepository))]
public class PartidoJudicialInhibicionRepository(PeitonDbContext dbContext) : RepositoryBase<PartidoJudicialInhibicion>(dbContext), IPartidoJudicialInhibicionRepository
{
}
