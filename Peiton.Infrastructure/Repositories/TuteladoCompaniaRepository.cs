using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoCompaniaRepository))]
public class TuteladoCompaniaRepository : RepositoryBase<TuteladoCompania>, ITuteladoCompaniaRepository
{
	public TuteladoCompaniaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
