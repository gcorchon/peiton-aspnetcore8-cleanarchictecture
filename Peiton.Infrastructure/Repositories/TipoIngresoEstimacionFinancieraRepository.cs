using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoIngresoEstimacionFinancieraRepository))]
public class TipoIngresoEstimacionFinancieraRepository : RepositoryBase<TipoIngresoEstimacionFinanciera>, ITipoIngresoEstimacionFinancieraRepository
{
	public TipoIngresoEstimacionFinancieraRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
