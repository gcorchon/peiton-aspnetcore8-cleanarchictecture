using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISolicitanteRevisionRepository))]
public class SolicitanteRevisionRepository : RepositoryBase<SolicitanteRevision>, ISolicitanteRevisionRepository
{
	public SolicitanteRevisionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
