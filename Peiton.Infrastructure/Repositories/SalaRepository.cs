using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ISalaRepository))]
	public class SalaRepository: RepositoryBase<Sala>, ISalaRepository
	{
		public SalaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}