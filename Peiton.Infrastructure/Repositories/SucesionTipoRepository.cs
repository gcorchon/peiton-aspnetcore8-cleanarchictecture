using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISucesionTipoRepository))]
public class SucesionTipoRepository : RepositoryBase<SucesionTipo>, ISucesionTipoRepository
{
	public SucesionTipoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
