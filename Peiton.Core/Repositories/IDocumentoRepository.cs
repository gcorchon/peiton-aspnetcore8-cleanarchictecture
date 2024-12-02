using Peiton.Contracts.Documentos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IDocumentoRepository : IRepository<Documento>
{
    Task<Documento[]> ObtenerDocumentosAsync();
}
