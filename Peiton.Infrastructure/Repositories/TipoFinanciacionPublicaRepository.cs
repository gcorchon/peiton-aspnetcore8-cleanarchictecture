using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoFinanciacionPublicaRepository))]
	public class TipoFinanciacionPublicaRepository: RepositoryBase<TipoFinanciacionPublica>, ITipoFinanciacionPublicaRepository
	{
		public TipoFinanciacionPublicaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}