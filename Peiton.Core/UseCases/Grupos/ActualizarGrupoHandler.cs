using Peiton.Contracts.Grupos;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Grupos;

[Injectable]
public class ActualizarGrupoHandler(IGrupoRepository grupoRepository, IPermisoRepository permisoRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, GuardarGrupoRequest request)
    {
        var grupo = await grupoRepository.GetByIdAsync(id);

        if (grupo == null) throw new EntityNotFoundException("Grupo no encontrado");

        grupo.Descripcion = request.Descripcion;

        grupo.Permisos.Merge(request.Permisos, p => p.Id, id =>
        {
            var permiso = new Permiso() { Id = id };
            permisoRepository.Attach(permiso);
            return permiso;
        });

        grupo.Usuarios.Merge(request.Usuarios, p => p.Id, id =>
        {
            var usuario = new Usuario() { Id = id };
            usuarioRepository.Attach(usuario);
            return usuario;
        });

        try
        {
            await unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null && ex.InnerException.Message.Contains("IX_Grupo"))
            {
                throw new ArgumentException($"Ya existe un grupo con el nombre \"{request.Descripcion}\"");
            }

            throw new Exception("Error no controlado", ex);
        }
    }
}