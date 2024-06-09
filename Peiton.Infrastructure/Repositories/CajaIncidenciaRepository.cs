using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICajaIncidenciaRepository))]
	public class CajaIncidenciaRepository: RepositoryBase<CajaIncidencia>, ICajaIncidenciaRepository
	{
		public CajaIncidenciaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}