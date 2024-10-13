using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoPagoRepository))]
public class TipoPagoRepository : RepositoryBase<TipoPago>, ITipoPagoRepository
{
	public TipoPagoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
