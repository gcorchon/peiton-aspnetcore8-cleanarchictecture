using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IClienteRepository))]
	public class ClienteRepository: RepositoryBase<Cliente>, IClienteRepository
	{
		public ClienteRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}