using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IAppMovilCumplimientoRepository))]
	public class AppMovilCumplimientoRepository: RepositoryBase<AppMovilCumplimiento>, IAppMovilCumplimientoRepository
	{
		public AppMovilCumplimientoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}