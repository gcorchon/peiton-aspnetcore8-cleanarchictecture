using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoServicioApoyoFormalRepository))]
	public class TipoServicioApoyoFormalRepository: RepositoryBase<TipoServicioApoyoFormal>, ITipoServicioApoyoFormalRepository
	{
		public TipoServicioApoyoFormalRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}