using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Instrucciones;

namespace Peiton.Core.UseCases.Instrucciones;

[Injectable]
public class InstruccionesHandler(IInstruccionRepository instruccionRepository)
{
    public async Task<IEnumerable<CategoriaInstruccionViewModel>> HandleAsync()
    {
        var listItems = await instruccionRepository.ObtenerInstruccionesAsync();
        return listItems
            .GroupBy(item => new { item.CategoriaInstruccionId, item.Categoria, item.CssClass })
            .Select(group => new CategoriaInstruccionViewModel
            {
                Id = group.Key.CategoriaInstruccionId,
                Descripcion = group.Key.Categoria,
                CssClass = group.Key.CssClass,
                Instrucciones = group.Select(i => new InstruccionViewModel
                {
                    Id = i.InstruccionId,
                    Descripcion = i.Descripcion,
                    ContentType = i.ContentType,
                    FileName = i.FileName,
                    Fecha = i.Fecha
                })
            });

    }
}
