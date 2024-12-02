using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaOrigenRepository))]
public class UrgenciaOrigenRepository(PeitonDbContext dbContext) : RepositoryBase<UrgenciaOrigen>(dbContext), IUrgenciaOrigenRepository
{
}
