using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Usuarios;

[Injectable]
public class BorrarUsuarioHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var usuario = await usuarioRepository.GetByIdAsync(id);
        if (usuario == null) throw new NotFoundException("Usuario no encontrado");
        usuario.Borrado = true;
        await unitOfWork.SaveChangesAsync();
    }
}