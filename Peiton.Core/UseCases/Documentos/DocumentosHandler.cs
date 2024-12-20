﻿using Peiton.Core.Repositories;
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
            .GroupBy(item => new { item.CategoriaDocumento.CategoriaDocumentoPadre!.Id, item.CategoriaDocumento.CategoriaDocumentoPadre!.Descripcion, item.CategoriaDocumento.CategoriaDocumentoPadre!.CssClass })
            .Select(group => new CategoriaDocumentoViewModel
            {
                Id = group.Key.Id,
                Descripcion = group.Key.Descripcion,
                CssClass = group.Key.CssClass,
                Documentos = group.Select(i => new DocumentoListItem
                {
                    Id = i.Id,
                    Subcategoria = i.CategoriaDocumento.Descripcion,
                    Descripcion = i.Descripcion,
                    Tags = i.Tags,
                    Fecha = i.Fecha
                }).OrderBy(d => d.Descripcion)
            })
            .OrderBy(item => item.Descripcion.StartsWith("Otros") ? 1 : 0)
            .ThenBy(item => item.Descripcion);

    }
}
