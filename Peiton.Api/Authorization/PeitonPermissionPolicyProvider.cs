using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Peiton.Api.Authorization;

internal class PeitonPermissionPolicyProvider : IAuthorizationPolicyProvider
{
    const string POLICY_PREFIX = "PeitonPermission";
    public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

    public PeitonPermissionPolicyProvider(IOptions<AuthorizationOptions> options)
    {
        FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetFallbackPolicyAsync();


    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
            int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var permission))
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new PeitonPermissionRequirement(permission));
            return Task.FromResult<AuthorizationPolicy?>(policy.Build());
        }

        return Task.FromResult<AuthorizationPolicy?>(null);
    }
}