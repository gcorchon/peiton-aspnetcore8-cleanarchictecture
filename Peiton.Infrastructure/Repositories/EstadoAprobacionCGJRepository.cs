using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEstadoAprobacionCGJRepository))]
public class EstadoAprobacionCGJRepository : RepositoryBase<EstadoAprobacionCGJ>, IEstadoAprobacionCGJRepository
{
	public EstadoAprobacionCGJRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
