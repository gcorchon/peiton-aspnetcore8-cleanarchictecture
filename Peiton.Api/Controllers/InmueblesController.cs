using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Inmuebles;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.UseCases.Inmuebles;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InmueblesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> InmueblesAsync([FromQuery][Required] int tuteladoId, InmueblesHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<InmuebleListItem>>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerInmuebleAsync(int id, InmuebleHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<InmuebleViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearInmuebleAsync(CrearInmuebleRequest request, CrearInmuebleHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarInmuebleAsync(int id, InmuebleViewModel request, ActualizarInmuebleHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarInmuebleAsync(int id, BorrarInmuebleHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}