using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFormaPagoGastoEstimacionFinancieraRepository))]
public class FormaPagoGastoEstimacionFinancieraRepository(PeitonDbContext dbContext) : RepositoryBase<FormaPagoGastoEstimacionFinanciera>(dbContext), IFormaPagoGastoEstimacionFinancieraRepository
{
}
