using Peiton.Contracts.Usuarios;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Usuarios;

[Injectable]
public class ObtenerUsuariosGruposHandler(IUsuarioRepository usuarioRepository)
{
    public Task<UsuarioTipo[]> HandleAsync(string q)
    {
        return usuarioRepository.ObtenerUsuariosGruposAsync(q, 10);
    }
}
