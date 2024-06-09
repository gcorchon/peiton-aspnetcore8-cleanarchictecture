using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICompanyRepository))]
	public class CompanyRepository: RepositoryBase<Company>, ICompanyRepository
	{
		public CompanyRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}