using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IActividadEspecializadaRepository))]
	public class ActividadEspecializadaRepository: RepositoryBase<ActividadEspecializada>, IActividadEspecializadaRepository
	{
		public ActividadEspecializadaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}