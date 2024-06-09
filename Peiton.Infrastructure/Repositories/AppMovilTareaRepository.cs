using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IAppMovilTareaRepository))]
	public class AppMovilTareaRepository: RepositoryBase<AppMovilTarea>, IAppMovilTareaRepository
	{
		public AppMovilTareaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}