using Microsoft.AspNetCore.Authorization;
using Peiton.Core;
using Peiton.Core.Repositories;

namespace Peiton.Api.Authorization;

internal class PeitonPermissionAuthorizationHandler : AuthorizationHandler<PeitonPermissionRequirement>
{
    private readonly IServiceProvider serviceProvider;

    public PeitonPermissionAuthorizationHandler(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PeitonPermissionRequirement requirement)
    {
        if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
        {

            var identityService = serviceProvider.GetRequiredService<IIdentityService>();

            //int userId = identityService.GetUserId();

            if (await identityService.HasPermissionAsync(requirement.Permission))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail(new AuthorizationFailureReason(this, "Falta el permiso " + requirement.Permission));
            }


            return;
        }
        else
        {
            context.Fail(new AuthorizationFailureReason(this, "Usuario no autenticado"));
        }


        return; //Task.CompletedTask;
    }
}
