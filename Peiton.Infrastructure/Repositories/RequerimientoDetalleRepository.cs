using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRequerimientoDetalleRepository))]
public class RequerimientoDetalleRepository(PeitonDbContext dbContext) : RepositoryBase<RequerimientoDetalle>(dbContext), IRequerimientoDetalleRepository
{
}
