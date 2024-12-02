using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;
[Injectable(typeof(IAbogadoExternoRepository))]
public class AbogadoExternoRepository(PeitonDbContext dbContext) : RepositoryBase<AbogadoExterno>(dbContext), IAbogadoExternoRepository
{
}
