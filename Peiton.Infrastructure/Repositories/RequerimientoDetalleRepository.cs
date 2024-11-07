using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRequerimientoDetalleRepository))]
public class RequerimientoDetalleRepository : RepositoryBase<RequerimientoDetalle>, IRequerimientoDetalleRepository
{
	public RequerimientoDetalleRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
