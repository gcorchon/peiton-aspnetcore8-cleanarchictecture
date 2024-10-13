using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILogCredencialRepository))]
public class LogCredencialRepository : RepositoryBase<LogCredencial>, ILogCredencialRepository
{
	public LogCredencialRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
