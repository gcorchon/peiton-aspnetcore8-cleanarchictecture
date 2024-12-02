using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoProductoRepository))]
public class TipoProductoRepository(PeitonDbContext dbContext) : RepositoryBase<TipoProducto>(dbContext), ITipoProductoRepository
{
}
