using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IPartidoJudicialRepository))]
	public class PartidoJudicialRepository: RepositoryBase<PartidoJudicial>, IPartidoJudicialRepository
	{
		public PartidoJudicialRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}