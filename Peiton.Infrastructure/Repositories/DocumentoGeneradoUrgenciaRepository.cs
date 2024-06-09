using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDocumentoGeneradoUrgenciaRepository))]
	public class DocumentoGeneradoUrgenciaRepository: RepositoryBase<DocumentoGeneradoUrgencia>, IDocumentoGeneradoUrgenciaRepository
	{
		public DocumentoGeneradoUrgenciaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}