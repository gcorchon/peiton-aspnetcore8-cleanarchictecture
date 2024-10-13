using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IActividadLocalizacionRepository))]
public class ActividadLocalizacionRepository : RepositoryBase<ActividadLocalizacion>, IActividadLocalizacionRepository
{
	public ActividadLocalizacionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
