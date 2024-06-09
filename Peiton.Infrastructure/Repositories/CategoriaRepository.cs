using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICategoriaRepository))]
	public class CategoriaRepository: RepositoryBase<Categoria>, ICategoriaRepository
	{
		public CategoriaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}