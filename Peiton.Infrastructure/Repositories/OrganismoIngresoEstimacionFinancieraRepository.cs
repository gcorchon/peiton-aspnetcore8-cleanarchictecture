using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IOrganismoIngresoEstimacionFinancieraRepository))]
	public class OrganismoIngresoEstimacionFinancieraRepository: RepositoryBase<OrganismoIngresoEstimacionFinanciera>, IOrganismoIngresoEstimacionFinancieraRepository
	{
		public OrganismoIngresoEstimacionFinancieraRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}