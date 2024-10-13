using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Categorias;
[Injectable]
public class BuscarCategoriasHandler(IVwCategoriaRepository categoriaRepository)
{
    public Task<List<VwCategoria>> HandleAsync(string text, int total)
    {
        return categoriaRepository.BuscarCategoriasAsync(text, total);
    }

}
