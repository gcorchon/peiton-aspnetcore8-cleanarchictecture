using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPartidoJudicialInhibicionRepository))]
public class PartidoJudicialInhibicionRepository : RepositoryBase<PartidoJudicialInhibicion>, IPartidoJudicialInhibicionRepository
{
	public PartidoJudicialInhibicionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
