using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICredencialRepository))]
	public class CredencialRepository: RepositoryBase<Credencial>, ICredencialRepository
	{
		public CredencialRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}