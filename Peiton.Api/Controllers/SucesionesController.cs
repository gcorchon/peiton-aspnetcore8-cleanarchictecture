using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Extensions;
using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Sucesiones;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SucesionesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> SucesionesAsync([FromQuery] SucesionesFilter filter, [FromQuery] Pagination pagination, SucesionesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<SucesionListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> SucesionAsync(int id, EntityHandler<Sucesion> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<SucesionViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarSucesionAsync(int id, ActualizarSucesionRequest request, ActualizarEntityHandler<Sucesion> handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearSucesionAsync(int id, CrearSucesionRequest request, CrearSucesionHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

}