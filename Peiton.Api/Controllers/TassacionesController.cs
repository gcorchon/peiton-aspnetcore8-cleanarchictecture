using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Extensions;
using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.InmuebleTasaciones;
using Peiton.Core.UseCases.Tasaciones;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasacionesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> TasacionesAsync([FromQuery] InmuebleTasacionesFilter filter, [FromQuery] Pagination pagination, InmuebleTasacionesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<InmuebleTasacionListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> TasacionAsync(int id, EntityHandler<InmuebleTasacion> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<InmuebleTasacionViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarTasacionAsync(int id, ActualizarInmuebleTasacionRequest request, ActualizarEntityHandler<InmuebleTasacion> handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearTasacionAsync(int inmuebleId, CrearInmuebleTasacionRequest request, CrearTasacionHandler handler)
    {
        await handler.HandleAsync(inmuebleId, request);
        return Accepted();
    }

}