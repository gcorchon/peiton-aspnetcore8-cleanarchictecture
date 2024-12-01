using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Archivos;
using Peiton.Core.Utils;

namespace Peiton.Core.UseCases.Archivos;

[Injectable]
public class ArchivosHandler(IArchivoRepository archivoRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<IEnumerable<CategoriaArchivoViewModel>> HandleAsync(int tuteladoId)
    {
        if (!await tuteladoRepository.CanModifyAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var listItems = await archivoRepository.ObtenerArchivosAsync(tuteladoId);
        return listItems
            .GroupBy(item => new { item.CategoriaArchivo.CategoriaArchivoPadre!.Id, item.CategoriaArchivo.CategoriaArchivoPadre!.Descripcion, item.CategoriaArchivo.CategoriaArchivoPadre!.CssClass })
            .Select(group => new CategoriaArchivoViewModel
            {
                Id = group.Key.Id,
                Descripcion = group.Key.Descripcion,
                CssClass = group.Key.CssClass ?? "",
                Archivos = group.Select(i => new ArchivoViewModel
                {
                    Id = i.Id,
                    Descripcion = i.Descripcion,
                    ContentType = i.ContentType,
                    FileName = i.FileName,
                    Tags = i.Tags,
                    TuAppoyo = i.TuAppoyo,
                    Fecha = i.Fecha
                })
            })
            .OrderBy(item => item.Descripcion.StartsWith("Otros") ? 1 : 0)
            .ThenBy(item => item.Descripcion);

    }
}
