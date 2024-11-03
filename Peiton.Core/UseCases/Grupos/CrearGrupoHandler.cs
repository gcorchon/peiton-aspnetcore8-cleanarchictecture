using Peiton.Contracts.Grupos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Grupos;

[Injectable]
public class CrearGrupoHandler(IGrupoRepository grupoRepository, IPermisoRepository permisoRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(GuardarGrupoRequest request)
    {
        var grupo = new Grupo();
        grupo.Descripcion = request.Descripcion;

        foreach (var permisoId in request.Permisos)
        {
            var permiso = new Permiso() { Id = permisoId };
            permisoRepository.Attach(permiso);
            grupo.Permisos.Add(permiso);
        }

        foreach (var usuarioId in request.Usuarios)
        {
            var usuario = new Usuario() { Id = usuarioId };
            usuarioRepository.Attach(usuario);
            grupo.Usuarios.Add(usuario);
        }

        grupoRepository.Add(grupo);

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
        }
    }
}