using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICategoriaDocumentoRepository))]
	public class CategoriaDocumentoRepository: RepositoryBase<CategoriaDocumento>, ICategoriaDocumentoRepository
	{
		public CategoriaDocumentoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}