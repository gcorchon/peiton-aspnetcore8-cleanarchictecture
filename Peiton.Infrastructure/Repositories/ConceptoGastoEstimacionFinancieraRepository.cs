using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IConceptoGastoEstimacionFinancieraRepository))]
public class ConceptoGastoEstimacionFinancieraRepository(PeitonDbContext dbContext) : RepositoryBase<ConceptoGastoEstimacionFinanciera>(dbContext), IConceptoGastoEstimacionFinancieraRepository
{
}
