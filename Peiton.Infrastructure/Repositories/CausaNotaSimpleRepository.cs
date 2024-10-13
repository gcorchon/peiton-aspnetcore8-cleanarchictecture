using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICausaNotaSimpleRepository))]
public class CausaNotaSimpleRepository : RepositoryBase<CausaNotaSimple>, ICausaNotaSimpleRepository
{
	public CausaNotaSimpleRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
