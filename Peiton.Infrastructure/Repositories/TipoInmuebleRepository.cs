using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoInmuebleRepository))]
	public class TipoInmuebleRepository: RepositoryBase<TipoInmueble>, ITipoInmuebleRepository
	{
		public TipoInmuebleRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}