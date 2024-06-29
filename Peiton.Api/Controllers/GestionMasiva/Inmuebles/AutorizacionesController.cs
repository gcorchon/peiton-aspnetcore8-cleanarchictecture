using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.AvisosTributarios;
using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.GestionMasiva;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[Route("api/[controller]")]
public class AutorizacionesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Autorizaciones([FromQuery] InmuebleAutorizacionesFilter filter, [FromQuery] Pagination pagination, AutorizacionesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<InmuebleAutorizacionListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Autorizacion(int id, EntityHandler<InmuebleAutorizacion> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<InmuebleAutorizacionViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarAutorizacion(int id, ActualizarInmuebleAutorizacionRequest request, ActualizarEntityHandler<InmuebleAutorizacion> handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }
    /*

    [HttpPost("{id:int}/resolver")]
    public async Task<IActionResult> ResolverAviso(int id, ResolverInmuebleAutorizacionHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarAviso(int id, [FromBody]GuardarInmuebleAutorizacionRequest request, ActualizarInmuebleAutorizacionHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }
    */
}