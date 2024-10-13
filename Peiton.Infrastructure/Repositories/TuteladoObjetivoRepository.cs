using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoObjetivoRepository))]
public class TuteladoObjetivoRepository : RepositoryBase<TuteladoObjetivo>, ITuteladoObjetivoRepository
{
	public TuteladoObjetivoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
