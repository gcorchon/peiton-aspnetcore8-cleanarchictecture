using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEscritoSucursalRepository))]
public class EscritoSucursalRepository(PeitonDbContext dbContext) : RepositoryBase<EscritoSucursal>(dbContext), IEscritoSucursalRepository
{
}
