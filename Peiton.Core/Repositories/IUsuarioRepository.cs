using Peiton.Contracts.Usuarios;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IUsuarioRepository : IRepository<Usuario>
{
    bool CanViewTutelado(int usuarioId, int tuteladoId);
    bool CanViewTutelado(int tuteladoId);
    IEnumerable<int> GetPermissions(int usuarioId);
    Task<IEnumerable<int>> GetPermissionsAsync(int usuarioId);
    bool HasPermission(int userId, int permisoId);
    Task<bool> HasPermissionAsync(int userId, int permisoId);
    Task<bool> HasPermissionAsync(int permisoId);
    Task<UsuarioTipo[]> ObtenerUsuariosGruposAsync(string q, int v);
    Task<Usuario?> ObtenerUsuarioAsync(string nombre);
    Task<Usuario[]> ObtenerUsuariosConPermisoAsync(int[] rcpt, int comunicacionesRecibirMensajesPorEmail);
    Task<Usuario[]> ObtenerUsuariosConGruposAsync();
    Task<Usuario[]> ObtenerUsuariosBloqueadosAsync(int page, int total, UsuariosBloqueadosFilter filter);
    Task<int> ContarUsuariosBloqueadosAsync(UsuariosBloqueadosFilter filter);
    Task<Usuario> GetMeAsync();
}
