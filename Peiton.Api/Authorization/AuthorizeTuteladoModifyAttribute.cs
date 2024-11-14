using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Peiton.Core.Repositories;

namespace Peiton.Api.Authorization;

public class AuthorizeTuteladoModifyAttribute : ServiceFilterAttribute
{
    public AuthorizeTuteladoModifyAttribute()
        : base(typeof(AuthorizeTuteladoModifyFilter))
    {

    }
}

public class AuthorizeTuteladoModifyFilter(ITuteladoRepository tuteladoRepository) : IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        int tuteladoId;
        if (!int.TryParse(context.RouteData.Values["id"]?.ToString(), out tuteladoId))
        {
            context.Result = new BadRequestResult();
            return;
        }

        if (!await tuteladoRepository.CanModifyAsync(tuteladoId))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}

