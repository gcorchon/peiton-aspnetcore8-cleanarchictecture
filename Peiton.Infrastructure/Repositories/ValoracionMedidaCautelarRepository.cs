using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionMedidaCautelarRepository))]
public class ValoracionMedidaCautelarRepository : RepositoryBase<ValoracionMedidaCautelar>, IValoracionMedidaCautelarRepository
{
	public ValoracionMedidaCautelarRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
