using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPuntoInformacionRepository))]
public class PuntoInformacionRepository : RepositoryBase<PuntoInformacion>, IPuntoInformacionRepository
{
	public PuntoInformacionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
