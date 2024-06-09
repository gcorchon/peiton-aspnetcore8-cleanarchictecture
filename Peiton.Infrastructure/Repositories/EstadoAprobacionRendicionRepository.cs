using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEstadoAprobacionRendicionRepository))]
	public class EstadoAprobacionRendicionRepository: RepositoryBase<EstadoAprobacionRendicion>, IEstadoAprobacionRendicionRepository
	{
		public EstadoAprobacionRendicionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}