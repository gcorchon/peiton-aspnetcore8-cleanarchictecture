using Microsoft.AspNetCore.Authorization;

namespace Peiton.Api.Authorization
{
    internal class PeitonPermissionRequirement : IAuthorizationRequirement
    {
        public int Permission { get; private set; }

        public PeitonPermissionRequirement(int permission) { Permission = permission; }
    }
}
