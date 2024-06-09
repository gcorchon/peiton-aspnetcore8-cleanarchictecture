using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IConceptoGastoEstimacionFinancieraRepository))]
	public class ConceptoGastoEstimacionFinancieraRepository: RepositoryBase<ConceptoGastoEstimacionFinanciera>, IConceptoGastoEstimacionFinancieraRepository
	{
		public ConceptoGastoEstimacionFinancieraRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}