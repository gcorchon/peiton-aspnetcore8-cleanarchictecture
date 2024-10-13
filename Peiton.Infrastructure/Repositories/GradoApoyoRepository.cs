using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IGradoApoyoRepository))]
public class GradoApoyoRepository : RepositoryBase<GradoApoyo>, IGradoApoyoRepository
{
	public GradoApoyoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
