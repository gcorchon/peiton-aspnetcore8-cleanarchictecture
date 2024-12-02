using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILogAccesoFiscaliaRepository))]
public class LogAccesoFiscaliaRepository(PeitonDbContext dbContext) : RepositoryBase<LogAccesoFiscalia>(dbContext), ILogAccesoFiscaliaRepository
{
}
