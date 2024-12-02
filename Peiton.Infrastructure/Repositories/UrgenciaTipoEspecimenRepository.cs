using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaTipoEspecimenRepository))]
public class UrgenciaTipoEspecimenRepository(PeitonDbContext dbContext) : RepositoryBase<UrgenciaTipoEspecimen>(dbContext), IUrgenciaTipoEspecimenRepository
{
}
