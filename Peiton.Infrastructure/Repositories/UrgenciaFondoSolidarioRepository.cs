using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaFondoSolidarioRepository))]
public class UrgenciaFondoSolidarioRepository(PeitonDbContext dbContext) : RepositoryBase<UrgenciaFondoSolidario>(dbContext), IUrgenciaFondoSolidarioRepository
{
}
