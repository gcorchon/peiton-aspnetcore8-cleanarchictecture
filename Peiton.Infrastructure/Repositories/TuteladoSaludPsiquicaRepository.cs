using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoSaludPsiquicaRepository))]
public class TuteladoSaludPsiquicaRepository : RepositoryBase<TuteladoSaludPsiquica>, ITuteladoSaludPsiquicaRepository
{
	public TuteladoSaludPsiquicaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
