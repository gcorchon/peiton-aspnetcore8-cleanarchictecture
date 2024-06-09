using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IUrgenciaFondoSolidarioRepository))]
	public class UrgenciaFondoSolidarioRepository: RepositoryBase<UrgenciaFondoSolidario>, IUrgenciaFondoSolidarioRepository
	{
		public UrgenciaFondoSolidarioRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}