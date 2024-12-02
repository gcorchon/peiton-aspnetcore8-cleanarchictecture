using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILogCredencialRepository))]
public class LogCredencialRepository(PeitonDbContext dbContext) : RepositoryBase<LogCredencial>(dbContext), ILogCredencialRepository
{
}
