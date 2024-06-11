using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Peiton.Core;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IIdentityService))]
public class IdentityService : IIdentityService
{
    private readonly ClaimsPrincipal claimsPrincipal;

    public IdentityService(ClaimsPrincipal claimsPrincipal)
    {
        this.claimsPrincipal = claimsPrincipal;
    }

    public int? GetUserId()
    {
        var claim = claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Sid);
        if (claim is null) return null;
        return Convert.ToInt32(claim.Value);
    }
}
