using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICausaNotaSimpleRepository))]
public class CausaNotaSimpleRepository(PeitonDbContext dbContext) : RepositoryBase<CausaNotaSimple>(dbContext), ICausaNotaSimpleRepository
{
}
