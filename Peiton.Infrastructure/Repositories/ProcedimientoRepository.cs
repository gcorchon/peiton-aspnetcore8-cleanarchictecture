using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IProcedimientoRepository))]
public class ProcedimientoRepository(PeitonDbContext dbContext) : RepositoryBase<Procedimiento>(dbContext), IProcedimientoRepository
{
}
