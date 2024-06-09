using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IIncidenciaEstadoRepository))]
	public class IncidenciaEstadoRepository: RepositoryBase<IncidenciaEstado>, IIncidenciaEstadoRepository
	{
		public IncidenciaEstadoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}