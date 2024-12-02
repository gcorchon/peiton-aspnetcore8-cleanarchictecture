using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IVoluntariadoRepository))]
public class VoluntariadoRepository(PeitonDbContext dbContext) : RepositoryBase<Voluntariado>(dbContext), IVoluntariadoRepository
{
}
