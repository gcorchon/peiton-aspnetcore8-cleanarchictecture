using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRelacionCentroResidentesRepository))]
public class RelacionCentroResidentesRepository(PeitonDbContext dbContext) : RepositoryBase<RelacionCentroResidentes>(dbContext), IRelacionCentroResidentesRepository
{
}
