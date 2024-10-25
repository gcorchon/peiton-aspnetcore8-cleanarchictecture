using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Security;
using Peiton.Core.UseCases.Security;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecurityController : ControllerBase
{
    [HttpPost("token")]
    public async Task<IActionResult> GetTokenAsync(TokenRequest request, GetTokenHandler handler)
    {
        try
        {
            var token = await handler.HandleAsync(request);
            return Ok(token);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpGet("me")]
    [Authorize()]
    public async Task<ActionResult<MeViewModel>> MeAsync(MeHandler handler)
    {
        try
        {
            var me = await handler.HandleAsync();
            return Ok(me);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("Usuario no autorizado");
        }
    }
}
