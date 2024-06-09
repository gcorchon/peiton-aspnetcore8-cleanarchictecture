using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICredencialCPRepository))]
	public class CredencialCPRepository: RepositoryBase<CredencialCP>, ICredencialCPRepository
	{
		public CredencialCPRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}