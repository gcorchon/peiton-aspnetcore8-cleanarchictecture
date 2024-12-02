using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaConceptoCosteRepository))]
public class UrgenciaConceptoCosteRepository(PeitonDbContext dbContext) : RepositoryBase<UrgenciaConceptoCoste>(dbContext), IUrgenciaConceptoCosteRepository
{
}
