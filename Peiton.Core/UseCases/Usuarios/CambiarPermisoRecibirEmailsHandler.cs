using Peiton.Authorization;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Usuarios;

[Injectable]
public class CambiarPermisoRecibirEmailsHandler(IUsuarioRepository usuarioRepository, IPermisoRepository permisoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync()
    {
        var usuario = await usuarioRepository.GetMeAsync();

        var permiso = usuario.Permisos.FirstOrDefault(p => p.Id == PeitonPermission.ComunicacionesRecibirMensajesPorEmail);
        if (permiso != null)
        {
            usuario.Permisos.Remove(permiso);
        }
        else
        {
            var newPermiso = new Permiso() { Id = PeitonPermission.ComunicacionesRecibirMensajesPorEmail };
            permisoRepository.Attach(newPermiso);
            usuario.Permisos.Add(newPermiso);
        }

        await unitOfWork.SaveChangesAsync();
    }
}