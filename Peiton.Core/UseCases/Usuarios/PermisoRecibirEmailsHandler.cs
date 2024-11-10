using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Usuarios;

[Injectable]
public class PermisoRecibirEmailsHandler(IUsuarioRepository usuarioRepository)
{
    public async Task<Usuario> HandleAsync()
    {
        return await usuarioRepository.GetMeAsync();
    }
}