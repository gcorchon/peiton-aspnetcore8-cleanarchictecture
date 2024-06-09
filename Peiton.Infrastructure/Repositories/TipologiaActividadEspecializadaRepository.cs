using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipologiaActividadEspecializadaRepository))]
	public class TipologiaActividadEspecializadaRepository: RepositoryBase<TipologiaActividadEspecializada>, ITipologiaActividadEspecializadaRepository
	{
		public TipologiaActividadEspecializadaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}