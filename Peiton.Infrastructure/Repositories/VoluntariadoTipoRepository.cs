using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IVoluntariadoTipoRepository))]
public class VoluntariadoTipoRepository(PeitonDbContext dbContext) : RepositoryBase<VoluntariadoTipo>(dbContext), IVoluntariadoTipoRepository
{
}
