using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILauRepository))]
public class LauRepository : RepositoryBase<Lau>, ILauRepository
{
	public LauRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
