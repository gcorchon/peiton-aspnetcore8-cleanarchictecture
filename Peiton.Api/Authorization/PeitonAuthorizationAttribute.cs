using Microsoft.AspNetCore.Authorization;

namespace Peiton.Api.Authorization;

internal class PeitonAuthorizationAttribute : AuthorizeAttribute
{
    const string POLICY_PREFIX = "PeitonPermission";

    public PeitonAuthorizationAttribute(int permission) => Permission = permission;

    public int Permission
    {
        get
        {
            if (int.TryParse(Policy?.Substring(POLICY_PREFIX.Length), out var permission))
            {
                return permission;
            }
            return default(int);
        }

        set
        {
            Policy = $"{POLICY_PREFIX}{value.ToString()}";
        }
    }
}

