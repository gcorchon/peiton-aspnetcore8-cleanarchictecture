using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IReglaRepository))]
public class ReglaRepository : RepositoryBase<Regla>, IReglaRepository
{
	public ReglaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
