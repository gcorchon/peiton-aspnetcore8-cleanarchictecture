using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInformePersonalPIARepository))]
	public class InformePersonalPIARepository: RepositoryBase<InformePersonalPIA>, IInformePersonalPIARepository
	{
		public InformePersonalPIARepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}