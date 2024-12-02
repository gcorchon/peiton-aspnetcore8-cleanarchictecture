using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaRepository))]
public class UrgenciaRepository(PeitonDbContext dbContext) : RepositoryBase<Urgencia>(dbContext), IUrgenciaRepository
{
}
