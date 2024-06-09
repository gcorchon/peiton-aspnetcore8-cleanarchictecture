using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoObjetivoRepository))]
	public class TipoObjetivoRepository: RepositoryBase<TipoObjetivo>, ITipoObjetivoRepository
	{
		public TipoObjetivoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}