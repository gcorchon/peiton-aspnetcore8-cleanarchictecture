using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        bool CanViewTutelado(int usuarioId, int tuteladoId);
        IEnumerable<int> GetPermissions(int usuarioId);
        Task<IEnumerable<int>> GetPermissionsAsync(int usuarioId);
        bool HasPermission(int userId, int permisoId);
        Task<bool> HasPermissionAsync(int userId, int permisoId);
    }
}