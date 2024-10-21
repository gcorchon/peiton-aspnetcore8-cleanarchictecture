using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Documentos;

namespace Peiton.Core.UseCases.Documentos;

[Injectable]
public class DocumentosHandler(IDocumentoRepository documentoRepository)
{
    public async Task<IEnumerable<CategoriaDocumentoViewModel>> HandleAsync()
    {
        var listItems = await documentoRepository.ObtenerDocumentosAsync();
        return listItems
            .GroupBy(item => new { item.CategoriaDocumentoId, item.Categoria, item.CssClass })
            .Select(group => new CategoriaDocumentoViewModel
            {
                Id = group.Key.CategoriaDocumentoId,
                Descripcion = group.Key.Categoria,
                CssClass = group.Key.CssClass,
                Documentos = group.Select(i => new DocumentoViewModel
                {
                    Id = i.DocumentoId,
                    Descripcion = i.Descripcion,
                    ContentType = i.ContentType,
                    FileName = i.FileName,
                    Fecha = i.Fecha
                })
            });

    }
}
