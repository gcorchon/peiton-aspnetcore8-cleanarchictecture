using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Procesos;

namespace Peiton.Core.UseCases.Procesos;

[Injectable]
public class CategoriaProcesosHandler(ICategoriaProcesoRepository categoriaProcesoRepository)
{
    public async Task<IEnumerable<CategoriaRaiz>> HandleAsync()
    {
        var listItems = await categoriaProcesoRepository.GetAllAsync();
        return listItems
                .Where(item => item.CategoriaProcesoId == null)
                .Select(item => new CategoriaRaiz
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion,
                    Categorias = listItems
                        .Where(sub => sub.CategoriaProcesoId == item.Id)
                        .Select(sub => new Categoria
                        {
                            Id = sub.Id,
                            Descripcion = sub.Descripcion
                        })
                });
    }
}
