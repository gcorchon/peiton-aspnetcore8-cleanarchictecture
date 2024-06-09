using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.AnoPresupuestario;
using Peiton.Contracts.Common;
using Peiton.Core.UseCases.Contabilidad.AnosPresupuestarios;
using Peiton.Api.Extensions;
using Peiton.Core.Exceptions;
using Peiton.Api.Authorization;
using Peiton.Authorization;

namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class AnoPresupuestarioController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> AnosPresupuestarios([FromQuery] AnoPresupuestarioFilter filter, [FromQuery] Pagination pagination, AnosPresupuestariosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<AnoPresupuestarioViewModel>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> AnoPrespuestarioUpdate(int id, [FromBody] AnoPrespuestarioUpdateRequest data, AnoPresupuestarioUpdateHandler handler)
    {
        try
        {
            await handler.HandleAsync(id, data);
            return Accepted();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> AnoPrespuestarioDelete(int id, AnoPresupuestarioDeleteHandler handler)
    {
        try
        {
            await handler.HandleAsync(id);
            return Accepted();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}
