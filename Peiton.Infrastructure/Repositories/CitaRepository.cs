using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICitaRepository))]
	public class CitaRepository: RepositoryBase<Cita>, ICitaRepository
	{
		public CitaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}