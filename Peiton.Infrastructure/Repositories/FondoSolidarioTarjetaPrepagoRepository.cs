using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFondoSolidarioTarjetaPrepagoRepository))]
public class FondoSolidarioTarjetaPrepagoRepository(PeitonDbContext dbContext) : RepositoryBase<FondoSolidarioTarjetaPrepago>(dbContext), IFondoSolidarioTarjetaPrepagoRepository
{
}
