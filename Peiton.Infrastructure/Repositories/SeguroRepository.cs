using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ISeguroRepository))]
	public class SeguroRepository: RepositoryBase<Seguro>, ISeguroRepository
	{
		public SeguroRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}