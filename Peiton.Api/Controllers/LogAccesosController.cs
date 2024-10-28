using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.LogAccesos;
using Peiton.Core.UseCases.LogAccesos;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class LogAccesosController : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.AdministrarLogDeAccesos)]
    public async Task<IActionResult> LogAccesosAsync([FromQuery] LogAccesosFilter filter, [FromQuery] Pagination pagination, LogAccesosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        return this.PaginatedResult(data.Items, data.Total);
    }
}
