using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IConceptoIngresoEstimacionFinancieraRepository))]
public class ConceptoIngresoEstimacionFinancieraRepository : RepositoryBase<ConceptoIngresoEstimacionFinanciera>, IConceptoIngresoEstimacionFinancieraRepository
{
	public ConceptoIngresoEstimacionFinancieraRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
