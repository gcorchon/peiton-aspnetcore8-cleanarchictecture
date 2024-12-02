using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEstadoInventarioRepository))]
public class EstadoInventarioRepository(PeitonDbContext dbContext) : RepositoryBase<EstadoInventario>(dbContext), IEstadoInventarioRepository
{
}
