using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;

using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Usuarios;

[Injectable]
public class DesbloquearUsuarioHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var usuario = await usuarioRepository.GetByIdAsync(id);
        if (usuario == null || !usuario.Bloqueado) throw new EntityNotFoundException("El usuario no existe o no está bloqueado");
        usuario.Bloqueado = false;
        usuario.Reintentos = 0;

        await unitOfWork.SaveChangesAsync();
    }
}