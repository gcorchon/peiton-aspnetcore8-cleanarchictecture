using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoPagoRepository))]
public class TipoPagoRepository(PeitonDbContext dbContext) : RepositoryBase<TipoPago>(dbContext), ITipoPagoRepository
{
}
