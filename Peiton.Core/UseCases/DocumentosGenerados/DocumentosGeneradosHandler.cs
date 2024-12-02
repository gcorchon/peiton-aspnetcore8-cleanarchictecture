using Peiton.Contracts.DocumentosGenerados;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.DocumentosGenerados;

[Injectable]
public class DocumentosGeneradosHandler(IDocumentoGeneradoRepository documentoGeneradoRepository)
{
    public async Task<IEnumerable<CategoriaDocumentoViewModel>> HandleAsync()
    {
        var listItems = await documentoGeneradoRepository.ObtenerDocumentosAsync();
        return listItems
            .GroupBy(item => new { item.CategoriaDocumentoGenerado.Id, item.CategoriaDocumentoGenerado.Descripcion, item.CategoriaDocumentoGenerado.CssClass })
            .Select(group => new CategoriaDocumentoViewModel
            {
                Id = group.Key.Id,
                Descripcion = group.Key.Descripcion,
                CssClass = group.Key.CssClass ?? "",
                Documentos = group.Select(i => new DocumentoListItem
                {
                    Id = i.Id,
                    Descripcion = i.Descripcion,
                    Tags = i.Tags,
                    Fecha = i.Fecha,
                }).OrderBy(d => d.Descripcion)
            })
            .OrderBy(item => item.Descripcion.StartsWith("Otros") ? 1 : 0)
            .ThenBy(item => item.Descripcion);
    }
}