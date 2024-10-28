using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Centros;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Centros;
using Peiton.Core.UseCases.Common;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CentrosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.AdministrarCentros)]
    public async Task<IActionResult> CentrosAsync([FromQuery] CentrosFilter filter, [FromQuery] Pagination pagination, CentrosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<CentroListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> CentroAsync(int id, EntityHandler<Centro> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<CentroViewModel>(data);
        return Ok(vm);
    }

    [HttpPost("")]
    [PeitonAuthorization(PeitonPermission.AdministrarCentrosEditar)]
    public async Task<IActionResult> CrearCentroAsync([FromBody] CentroViewModel data, CrearEntityHandler<Centro> handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    [PeitonAuthorization(PeitonPermission.AdministrarCentrosEditar)]
    public async Task<IActionResult> ActualizarCentroAsync(int id, [FromBody] CentroViewModel data, ActualizarEntityHandler<Centro> handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    [PeitonAuthorization(PeitonPermission.AdministrarCentrosEditar)]
    public async Task<IActionResult> BorrarClienteAsync(int id, DeleteEntityHandler<Centro> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

}
