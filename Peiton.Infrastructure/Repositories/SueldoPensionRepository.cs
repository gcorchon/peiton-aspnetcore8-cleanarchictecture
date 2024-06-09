using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ISueldoPensionRepository))]
	public class SueldoPensionRepository: RepositoryBase<SueldoPension>, ISueldoPensionRepository
	{
		public SueldoPensionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}