using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IAppMovilTipoTareaRepository))]
	public class AppMovilTipoTareaRepository: RepositoryBase<AppMovilTipoTarea>, IAppMovilTipoTareaRepository
	{
		public AppMovilTipoTareaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}