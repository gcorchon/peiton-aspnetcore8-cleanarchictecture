using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IOtroAsuntoTipoRepository))]
public class OtroAsuntoTipoRepository : RepositoryBase<OtroAsuntoTipo>, IOtroAsuntoTipoRepository
{
	public OtroAsuntoTipoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
