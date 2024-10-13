using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEstadoRetribucionRepository))]
public class EstadoRetribucionRepository : RepositoryBase<EstadoRetribucion>, IEstadoRetribucionRepository
{
	public EstadoRetribucionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
