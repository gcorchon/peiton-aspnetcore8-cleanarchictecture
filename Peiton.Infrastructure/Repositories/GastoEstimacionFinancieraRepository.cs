using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IGastoEstimacionFinancieraRepository))]
	public class GastoEstimacionFinancieraRepository: RepositoryBase<GastoEstimacionFinanciera>, IGastoEstimacionFinancieraRepository
	{
		public GastoEstimacionFinancieraRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}