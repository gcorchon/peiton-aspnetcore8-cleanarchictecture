using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaTipoRepository))]
public class UrgenciaTipoRepository(PeitonDbContext dbContext) : RepositoryBase<UrgenciaTipo>(dbContext), IUrgenciaTipoRepository
{
}
