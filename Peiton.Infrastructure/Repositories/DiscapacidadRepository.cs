using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDiscapacidadRepository))]
	public class DiscapacidadRepository: RepositoryBase<Discapacidad>, IDiscapacidadRepository
	{
		public DiscapacidadRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}