using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Deposits;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepositsController : ControllerBase
{
    [HttpPatch("{id:int}/baja")]
    public async Task<IActionResult> DarDeBajaAsync(int id, DarDeBajaHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}