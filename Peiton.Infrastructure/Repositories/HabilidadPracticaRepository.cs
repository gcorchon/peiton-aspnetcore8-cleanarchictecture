using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IHabilidadPracticaRepository))]
	public class HabilidadPracticaRepository: RepositoryBase<HabilidadPractica>, IHabilidadPracticaRepository
	{
		public HabilidadPracticaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}