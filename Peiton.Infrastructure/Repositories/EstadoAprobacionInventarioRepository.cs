using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEstadoAprobacionInventarioRepository))]
	public class EstadoAprobacionInventarioRepository: RepositoryBase<EstadoAprobacionInventario>, IEstadoAprobacionInventarioRepository
	{
		public EstadoAprobacionInventarioRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}