using AutoMapper;
using Peiton.Contracts.Usuarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Usuarios;

[Injectable]
public class CrearUsuarioHandler(IMapper mapper, IUsuarioRepository usuarioRepository, IPermisoRepository permisoRepository, IGrupoRepository grupoRepository, ICryptographyService cryptographyService, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(GuardarUsuarioRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Pwd)) throw new ArgumentException("La password es obligatoria");

        var usuario = mapper.Map(request, new Usuario());

        usuario.Pwd = cryptographyService.GetMd5Hash(request.Pwd!);
        usuario.Borrado = false;

        foreach (var permisoId in request.Permisos)
        {
            var permiso = new Permiso() { Id = permisoId };
            permisoRepository.Attach(permiso);
            usuario.Permisos.Add(permiso);
        }

        foreach (var grupoId in request.Grupos)
        {
            var grupo = new Grupo() { Id = grupoId };
            grupoRepository.Attach(grupo);
            usuario.Grupos.Add(grupo);
        }

        usuarioRepository.Add(usuario);

        try
        {
            await unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                var innerExceptionMsg = ex.InnerException.Message;
                if (innerExceptionMsg.Contains("IX_Email")) throw new ArgumentException($"Ya existe un usuario con el email \"{request.Email}\"");
                if (innerExceptionMsg.Contains("IX_Usuario")) throw new ArgumentException($"Ya existe un usuario \"{request.Username}\"");
            }
            throw new Exception("Error no controlado", ex);
        }
    }
}