using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDatosEconomicosRepository))]
	public class DatosEconomicosRepository: RepositoryBase<DatosEconomicos>, IDatosEconomicosRepository
	{
		public DatosEconomicosRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}