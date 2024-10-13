using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleMotivoAutorizacionRepository))]
public class InmuebleMotivoAutorizacionRepository : RepositoryBase<InmuebleMotivoAutorizacion>, IInmuebleMotivoAutorizacionRepository
{
	public InmuebleMotivoAutorizacionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
