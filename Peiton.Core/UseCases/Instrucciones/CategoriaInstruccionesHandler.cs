using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Instrucciones;

namespace Peiton.Core.UseCases.Instrucciones;

[Injectable]
public class CategoriaInstruccionesHandler(ICategoriaInstruccionRepository categoriaInstruccionRepository)
{
    public async Task<IEnumerable<CategoriaRaiz>> HandleAsync()
    {
        var listItems = await categoriaInstruccionRepository.GetAllAsync();
        return listItems
                .Where(item => item.CategoriaInstruccionId == null)
                .Select(item => new CategoriaRaiz
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion,
                    Categorias = listItems
                        .Where(sub => sub.CategoriaInstruccionId == item.Id)
                        .Select(sub => new Categoria
                        {
                            Id = sub.Id,
                            Descripcion = sub.Descripcion
                        })
                });
    }
}
