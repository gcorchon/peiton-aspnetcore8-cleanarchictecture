using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISolicitanteRevisionRepository))]
public class SolicitanteRevisionRepository(PeitonDbContext dbContext) : RepositoryBase<SolicitanteRevision>(dbContext), ISolicitanteRevisionRepository
{
}
