using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Archivos;

namespace Peiton.Core.UseCases.Archivos;

[Injectable]
public class CategoriaArchivosHandler(ICategoriaArchivoRepository categoriaArchivoRepository)
{
    public async Task<IEnumerable<CategoriaRaiz>> HandleAsync()
    {
        var listItems = await categoriaArchivoRepository.GetAllAsync();
        return listItems
                .Where(item => item.CategoriaArchivoId == null)
                .Select(item => new CategoriaRaiz
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion,
                    Categorias = listItems
                        .Where(sub => sub.CategoriaArchivoId == item.Id)
                        .Select(sub => new Categoria
                        {
                            Id = sub.Id,
                            Descripcion = sub.Descripcion
                        })
                });
    }
}
