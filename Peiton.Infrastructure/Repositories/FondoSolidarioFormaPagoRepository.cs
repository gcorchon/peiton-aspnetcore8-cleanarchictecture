using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFondoSolidarioFormaPagoRepository))]
public class FondoSolidarioFormaPagoRepository(PeitonDbContext dbContext) : RepositoryBase<FondoSolidarioFormaPago>(dbContext), IFondoSolidarioFormaPagoRepository
{
}
