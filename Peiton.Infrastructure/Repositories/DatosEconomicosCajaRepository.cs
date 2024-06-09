using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDatosEconomicosCajaRepository))]
	public class DatosEconomicosCajaRepository: RepositoryBase<DatosEconomicosCaja>, IDatosEconomicosCajaRepository
	{
		public DatosEconomicosCajaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}