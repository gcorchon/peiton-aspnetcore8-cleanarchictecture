using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IDocumentoGeneradoRepository : IRepository<DocumentoGenerado>
{
    Task<DocumentoGenerado[]> ObtenerDocumentosAsync();
}
