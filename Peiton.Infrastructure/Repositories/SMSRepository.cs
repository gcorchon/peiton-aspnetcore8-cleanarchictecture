using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ISMSRepository))]
	public class SMSRepository: RepositoryBase<SMS>, ISMSRepository
	{
		public SMSRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}