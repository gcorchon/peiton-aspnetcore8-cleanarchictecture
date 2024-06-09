using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IPuntoInformacionTipoConsultaRepository))]
	public class PuntoInformacionTipoConsultaRepository: RepositoryBase<PuntoInformacionTipoConsulta>, IPuntoInformacionTipoConsultaRepository
	{
		public PuntoInformacionTipoConsultaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}