using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IControlRendicionRepository))]
public class ControlRendicionRepository : RepositoryBase<ControlRendicion>, IControlRendicionRepository
{
	public ControlRendicionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
