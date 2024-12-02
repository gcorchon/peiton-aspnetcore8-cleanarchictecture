using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFondoSolidarioTipoFondoRepository))]
public class FondoSolidarioTipoFondoRepository(PeitonDbContext dbContext) : RepositoryBase<FondoSolidarioTipoFondo>(dbContext), IFondoSolidarioTipoFondoRepository
{
}
