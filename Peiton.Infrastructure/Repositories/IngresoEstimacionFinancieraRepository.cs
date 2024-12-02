using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IIngresoEstimacionFinancieraRepository))]
public class IngresoEstimacionFinancieraRepository(PeitonDbContext dbContext) : RepositoryBase<IngresoEstimacionFinanciera>(dbContext), IIngresoEstimacionFinancieraRepository
{
}
