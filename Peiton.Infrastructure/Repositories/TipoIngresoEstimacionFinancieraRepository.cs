using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoIngresoEstimacionFinancieraRepository))]
public class TipoIngresoEstimacionFinancieraRepository(PeitonDbContext dbContext) : RepositoryBase<TipoIngresoEstimacionFinanciera>(dbContext), ITipoIngresoEstimacionFinancieraRepository
{
}
