using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionEstadoRepository))]
public class ValoracionEstadoRepository : RepositoryBase<ValoracionEstado>, IValoracionEstadoRepository
{
	public ValoracionEstadoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
