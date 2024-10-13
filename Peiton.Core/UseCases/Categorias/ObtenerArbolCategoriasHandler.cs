using Peiton.Contracts.Categorias;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Categorias;
[Injectable]
public class ObtenerArbolCategoriasHandler(IVwCategoriaRepository vwCategoriaRepository)
{
    public async Task<IEnumerable<CategoryTree>> HandleAsync()
    {
        var categorias = await vwCategoriaRepository.ObtenerCategoriasAsync();

        var categoriasRaiz = categorias.Where(c => !c.VwCategoriaPadreId.HasValue).Select(c => new CategoryTree()
        {
            Id = c.Id,
            Descripcion = c.Descripcion
        }).ToList();

        categoriasRaiz.ForEach(categoria => CreateTree(categoria, categorias));

        return categoriasRaiz;
    }

    private void CreateTree(CategoryTree subtree, IEnumerable<VwCategoria> categorias)
    {
        var subcategories = categorias.Where(c => c.VwCategoriaPadreId == subtree.Id).Select(c => new CategoryTree()
        {
            Id = c.Id,
            Descripcion = c.Descripcion
        }).ToList();

        if (subcategories.Any())
        {
            subtree.Subcategorias = new List<CategoryTree>(subcategories);
            subcategories.ForEach(child => CreateTree(child, categorias));
        }
    }
}
