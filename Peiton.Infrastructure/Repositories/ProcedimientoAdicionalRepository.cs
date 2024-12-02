using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IProcedimientoAdicionalRepository))]
public class ProcedimientoAdicionalRepository(PeitonDbContext dbContext) : RepositoryBase<ProcedimientoAdicional>(dbContext), IProcedimientoAdicionalRepository
{
}
