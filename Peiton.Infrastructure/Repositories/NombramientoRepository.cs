using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(INombramientoRepository))]
	public class NombramientoRepository: RepositoryBase<Nombramiento>, INombramientoRepository
	{
		public NombramientoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}