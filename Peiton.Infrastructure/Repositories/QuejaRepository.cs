using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IQuejaRepository))]
	public class QuejaRepository: RepositoryBase<Queja>, IQuejaRepository
	{
		public QuejaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}