using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICategoriaArchivoRepository))]
	public class CategoriaArchivoRepository: RepositoryBase<CategoriaArchivo>, ICategoriaArchivoRepository
	{
		public CategoriaArchivoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}