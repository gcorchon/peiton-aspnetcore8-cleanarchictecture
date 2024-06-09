using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICNAERepository))]
	public class CNAERepository: RepositoryBase<CNAE>, ICNAERepository
	{
		public CNAERepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}