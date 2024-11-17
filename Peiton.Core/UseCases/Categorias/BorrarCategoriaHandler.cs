using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Categorias;
[Injectable]
public class BorrarCategoriaHandler(ICategoriaRepository categoriaRepository)
{
    public async Task HandleAsync(int id)
    {
        var categoria = await categoriaRepository.GetByIdAsync(id);
        if (categoria == null) { throw new NotFoundException($"La categoría {id} no existe"); }
        await categoriaRepository.BorrarCategoriaAsync(id);
    }

}
