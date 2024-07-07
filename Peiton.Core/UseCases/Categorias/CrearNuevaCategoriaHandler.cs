using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Categorias
{
    [Injectable]
    public class CrearNuevaCategoriaHandler(ICategoriaRepository categoriaRepository, IUnityOfWork unityOfWork)
    {
        public async Task<Categoria> HandleAsync(int categoriaPadreId)
        {
            var categoriaPadre = await categoriaRepository.GetByIdAsync(categoriaPadreId);
            if (categoriaPadre == null) throw new NotFoundException($"Categoría {categoriaPadreId} no encontrada");

            var categoria = new Categoria();
            categoria.Descripcion = "NUEVA CATEGORÍA";
            categoria.TipoCategoriaId = categoriaPadre.TipoCategoriaId;
            categoria.CategoriaPadreId = categoriaPadreId;

            await categoriaRepository.AddAsync(categoria);

            await unityOfWork.SaveChangesAsync();

            return categoria;
        }
    }
}
