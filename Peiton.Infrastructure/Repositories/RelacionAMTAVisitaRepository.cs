using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRelacionAMTAVisitaRepository))]
public class RelacionAMTAVisitaRepository(PeitonDbContext dbContext) : RepositoryBase<RelacionAMTAVisita>(dbContext), IRelacionAMTAVisitaRepository
{
}
