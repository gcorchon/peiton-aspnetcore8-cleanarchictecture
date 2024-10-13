using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.AnoPresupuestario;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.AnosPresupuestarios;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class AnoPresupuestarioController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> AnosPresupuestariosAsync([FromQuery] AnoPresupuestarioFilter filter, [FromQuery] Pagination pagination, AnosPresupuestariosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<AnoPresupuestarioViewModel>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> AnoPrespuestarioUpdateAsync(int id, [FromBody] AnoPrespuestarioUpdateRequest data, AnoPresupuestarioUpdateHandler handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> AnoPrespuestarioDeleteAsync(int id, AnoPresupuestarioDeleteHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}
