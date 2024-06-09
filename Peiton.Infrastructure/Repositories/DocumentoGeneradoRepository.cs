using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDocumentoGeneradoRepository))]
	public class DocumentoGeneradoRepository: RepositoryBase<DocumentoGenerado>, IDocumentoGeneradoRepository
	{
		public DocumentoGeneradoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}