using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IComunidadAutonomaRepository))]
	public class ComunidadAutonomaRepository: RepositoryBase<ComunidadAutonoma>, IComunidadAutonomaRepository
	{
		public ComunidadAutonomaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}