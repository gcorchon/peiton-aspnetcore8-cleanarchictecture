using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Documentos;

namespace Peiton.Core.UseCases.Documentos;

[Injectable]
public class CategoriaDocumentosHandler(ICategoriaDocumentoRepository categoriaDocumentoRepository)
{
    public async Task<IEnumerable<CategoriaRaiz>> HandleAsync()
    {
        var listItems = await categoriaDocumentoRepository.GetAllAsync();
        return listItems
                .Where(item => item.CategoriaDocumentoId == null)
                .Select(item => new CategoriaRaiz
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion,
                    Categorias = listItems
                        .Where(sub => sub.CategoriaDocumentoId == item.Id)
                        .Select(sub => new Categoria
                        {
                            Id = sub.Id,
                            Descripcion = sub.Descripcion
                        })
                });
    }
}
