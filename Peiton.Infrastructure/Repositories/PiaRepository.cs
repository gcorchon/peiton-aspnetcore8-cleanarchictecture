using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IPiaRepository))]
	public class PiaRepository: RepositoryBase<Pia>, IPiaRepository
	{
		public PiaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}