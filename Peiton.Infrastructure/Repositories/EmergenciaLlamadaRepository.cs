using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEmergenciaLlamadaRepository))]
public class EmergenciaLlamadaRepository : RepositoryBase<EmergenciaLlamada>, IEmergenciaLlamadaRepository
{
	public EmergenciaLlamadaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
