using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICategoriaConsultaRepository))]
	public class CategoriaConsultaRepository: RepositoryBase<CategoriaConsulta>, ICategoriaConsultaRepository
	{
		public CategoriaConsultaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}