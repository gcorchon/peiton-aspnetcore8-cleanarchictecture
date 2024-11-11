using Peiton.Contracts.Usuarios;

namespace Peiton.Core;

public interface IIdentityService
{
    int GetUserId();
    Task<bool> HasPermissionAsync(int permissionId);
    Task<Info> GetUserProfileAsync();
}
