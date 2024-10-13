using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Extensions;
using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.InmuebleAvisos;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AvisosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> AvisosAsync([FromQuery] InmuebleAvisosFilter filter, [FromQuery] Pagination pagination, AvisosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<InmuebleAvisoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> AvisoAsync(int id, EntityHandler<InmuebleAviso> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<InmuebleAvisoViewModel>(data);
        return Ok(vm);
    }


    [HttpPost("{id:int}/resolver")]
    public async Task<IActionResult> ResolverAvisoAsync(int id, ResolverInmuebleAvisoHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarAvisoAsync(int id, [FromBody] GuardarInmuebleAvisoRequest request, ActualizarInmuebleAvisoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }
}