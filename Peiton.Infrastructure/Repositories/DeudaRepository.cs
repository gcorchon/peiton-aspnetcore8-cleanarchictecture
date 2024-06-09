using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDeudaRepository))]
	public class DeudaRepository: RepositoryBase<Deuda>, IDeudaRepository
	{
		public DeudaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}