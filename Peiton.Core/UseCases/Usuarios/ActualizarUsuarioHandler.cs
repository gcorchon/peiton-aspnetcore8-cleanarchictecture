using AutoMapper;
using Peiton.Contracts.Usuarios;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Usuarios;

[Injectable]
public class ActualizarUsuarioHandler(IMapper mapper, IUsuarioRepository usuarioRepository, IPermisoRepository permisoRepository, IGrupoRepository grupoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, GuardarUsuarioRequest request)
    {
        var entity = await usuarioRepository.GetByIdAsync(id);
        if (entity == null) throw new NotFoundException("Usuario no encontrado");
        var usuario = mapper.Map(request, entity);

        if (!string.IsNullOrWhiteSpace(request.Pwd))
        {
            usuario.Pwd = Cryptography.GetMd5Hash(request.Pwd!);
        }

        usuario.Permisos.Merge(request.Permisos, p => p.Id, permisoId =>
            permisoRepository.Attach(new Permiso() { Id = permisoId })
        );

        usuario.Grupos.Merge(request.Grupos, g => g.Id, grupoId =>
            grupoRepository.Attach(new Grupo() { Id = grupoId })
        );

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