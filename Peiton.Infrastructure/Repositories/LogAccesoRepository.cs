using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILogAccesoRepository))]
public class LogAccesoRepository : RepositoryBase<LogAcceso>, ILogAccesoRepository
{
	public LogAccesoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
