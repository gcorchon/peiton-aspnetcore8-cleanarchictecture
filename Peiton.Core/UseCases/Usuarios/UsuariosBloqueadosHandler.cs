using Peiton.Contracts.Common;
using Peiton.Contracts.Usuarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Usuarios;

[Injectable]
public class UsuariosBloqueadosHandler(IUsuarioRepository usuarioRepository)
{
    public async Task<PaginatedData<Usuario>> HandleAsync(UsuariosBloqueadosFilter filter, Pagination pagination)
    {
        var items = await usuarioRepository.ObtenerUsuariosBloqueadosAsync(pagination.Page, pagination.Total, filter);
        var total = await usuarioRepository.ContarUsuariosBloqueadosAsync(filter);

        return new PaginatedData<Usuario>()
        {
            Items = items,
            Total = total
        };
    }
}