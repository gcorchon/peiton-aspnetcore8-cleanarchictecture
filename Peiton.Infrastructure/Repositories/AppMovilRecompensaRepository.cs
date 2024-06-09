using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IAppMovilRecompensaRepository))]
	public class AppMovilRecompensaRepository: RepositoryBase<AppMovilRecompensa>, IAppMovilRecompensaRepository
	{
		public AppMovilRecompensaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}