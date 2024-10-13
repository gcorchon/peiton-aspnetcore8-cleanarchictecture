using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAdhesionTratamientoRepository))]
public class AdhesionTratamientoRepository : RepositoryBase<AdhesionTratamiento>, IAdhesionTratamientoRepository
{
	public AdhesionTratamientoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
