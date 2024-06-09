using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEconomicoRepository))]
	public class EconomicoRepository: RepositoryBase<Economico>, IEconomicoRepository
	{
		public EconomicoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}