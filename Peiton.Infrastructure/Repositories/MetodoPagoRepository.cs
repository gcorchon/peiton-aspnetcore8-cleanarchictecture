using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMetodoPagoRepository))]
public class MetodoPagoRepository(PeitonDbContext dbContext) : RepositoryBase<MetodoPago>(dbContext), IMetodoPagoRepository
{
}
