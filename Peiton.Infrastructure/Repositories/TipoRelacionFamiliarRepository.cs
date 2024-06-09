using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoRelacionFamiliarRepository))]
	public class TipoRelacionFamiliarRepository: RepositoryBase<TipoRelacionFamiliar>, ITipoRelacionFamiliarRepository
	{
		public TipoRelacionFamiliarRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}