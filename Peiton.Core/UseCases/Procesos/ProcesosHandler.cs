using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Procesos;

namespace Peiton.Core.UseCases.Procesos;

[Injectable]
public class ProcesosHandler(IProcesoRepository procesoRepository)
{
    public async Task<IEnumerable<CategoriaProcesoViewModel>> HandleAsync()
    {
        var listItems = await procesoRepository.ObtenerProcesosAsync();
        return listItems
            .GroupBy(item => new { item.CategoriaProcesoId, item.Categoria, item.CssClass })
            .Select(group => new CategoriaProcesoViewModel
            {
                Id = group.Key.CategoriaProcesoId,
                Descripcion = group.Key.Categoria,
                CssClass = group.Key.CssClass,
                Procesos = group.Select(i => new ProcesoViewModel
                {
                    Id = i.ProcesoId,
                    Descripcion = i.Descripcion,
                    ContentType = i.ContentType,
                    FileName = i.FileName,
                    Fecha = i.Fecha
                })
            });

    }
}
