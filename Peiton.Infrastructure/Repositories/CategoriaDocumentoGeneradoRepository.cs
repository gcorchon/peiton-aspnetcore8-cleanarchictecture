using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICategoriaDocumentoGeneradoRepository))]
	public class CategoriaDocumentoGeneradoRepository: RepositoryBase<CategoriaDocumentoGenerado>, ICategoriaDocumentoGeneradoRepository
	{
		public CategoriaDocumentoGeneradoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}