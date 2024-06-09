using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IPartidaRepository))]
	public class PartidaRepository: RepositoryBase<Partida>, IPartidaRepository
	{
		public PartidaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}