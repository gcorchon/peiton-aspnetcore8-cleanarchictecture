using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IErrorLogRepository))]
public class ErrorLogRepository(PeitonDbContext dbContext) : RepositoryBase<ErrorLog>(dbContext), IErrorLogRepository
{
}
