using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAppMovilTuteladoRecompensaRepository))]
public class AppMovilTuteladoRecompensaRepository : RepositoryBase<AppMovilTuteladoRecompensa>, IAppMovilTuteladoRecompensaRepository
{
	public AppMovilTuteladoRecompensaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
