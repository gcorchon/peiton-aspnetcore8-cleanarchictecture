using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDocumentoGeneradoUrgenciaRepository))]
public class DocumentoGeneradoUrgenciaRepository(PeitonDbContext dbContext) : RepositoryBase<DocumentoGeneradoUrgencia>(dbContext), IDocumentoGeneradoUrgenciaRepository
{
}
