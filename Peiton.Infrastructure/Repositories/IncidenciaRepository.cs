using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


	[Injectable(typeof(IIncidenciaRepository))]
	public class IncidenciaRepository : RepositoryBase<Incidencia>, IIncidenciaRepository
	{
		public IncidenciaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}



	}
}