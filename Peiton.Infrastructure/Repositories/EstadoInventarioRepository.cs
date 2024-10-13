using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEstadoInventarioRepository))]
public class EstadoInventarioRepository : RepositoryBase<EstadoInventario>, IEstadoInventarioRepository
{
	public EstadoInventarioRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
