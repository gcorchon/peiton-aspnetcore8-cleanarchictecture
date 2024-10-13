using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IActividadRepository))]
public class ActividadRepository : RepositoryBase<Actividad>, IActividadRepository
{
	public ActividadRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
