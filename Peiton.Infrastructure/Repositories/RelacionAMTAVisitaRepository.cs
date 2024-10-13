using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRelacionAMTAVisitaRepository))]
public class RelacionAMTAVisitaRepository : RepositoryBase<RelacionAMTAVisita>, IRelacionAMTAVisitaRepository
{
	public RelacionAMTAVisitaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
