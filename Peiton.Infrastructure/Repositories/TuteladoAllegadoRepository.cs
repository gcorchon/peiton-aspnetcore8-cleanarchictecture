using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoAllegadoRepository))]
public class TuteladoAllegadoRepository : RepositoryBase<TuteladoAllegado>, ITuteladoAllegadoRepository
{
	public TuteladoAllegadoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
