using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITeAppoyoRepository))]
public class TeAppoyoRepository : RepositoryBase<TeAppoyo>, ITeAppoyoRepository
{
	public TeAppoyoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
