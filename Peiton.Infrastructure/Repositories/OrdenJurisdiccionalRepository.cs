using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IOrdenJurisdiccionalRepository))]
	public class OrdenJurisdiccionalRepository: RepositoryBase<OrdenJurisdiccional>, IOrdenJurisdiccionalRepository
	{
		public OrdenJurisdiccionalRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}