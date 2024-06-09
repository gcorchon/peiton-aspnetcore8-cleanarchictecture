using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IRelacionCentroProfesionalesRepository))]
	public class RelacionCentroProfesionalesRepository: RepositoryBase<RelacionCentroProfesionales>, IRelacionCentroProfesionalesRepository
	{
		public RelacionCentroProfesionalesRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}