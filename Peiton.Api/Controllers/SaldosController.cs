﻿using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Core.UseCases.Asientos;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class SaldosController : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> SaldosAsync([FromQuery] SaldosFilter filter, [FromQuery] Pagination pagination, [FromQuery] int ano, SaldosHandler handler)
    {
        var data = await handler.HandleAsync(ano, filter, pagination);
        return this.PaginatedResult(data.Items, data.Total);
    }
}


