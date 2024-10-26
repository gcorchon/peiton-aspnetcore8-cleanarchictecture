using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Categorias;
[Injectable]
public class CrearNuevaCategoriaHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
{
    public async Task<Categoria> HandleAsync(int categoriaPadreId)
    {
        var categoriaPadre = await categoriaRepository.GetByIdAsync(categoriaPadreId);
        if (categoriaPadre == null) throw new EntityNotFoundException($"Categoría {categoriaPadreId} no encontrada");

        var categoria = new Categoria();
        categoria.Descripcion = "NUEVA CATEGORÍA";
        categoria.TipoCategoriaId = categoriaPadre.TipoCategoriaId;
        categoria.CategoriaPadreId = categoriaPadreId;

        await categoriaRepository.AddAsync(categoria);

        await unitOfWork.SaveChangesAsync();

        return categoria;
    }
}
