using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IErrorLogRepository))]
public class ErrorLogRepository : RepositoryBase<ErrorLog>, IErrorLogRepository
{
	public ErrorLogRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
