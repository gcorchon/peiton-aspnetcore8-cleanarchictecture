using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Arrendamientos;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.UseCases.Arrendamientos;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArrendamientosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> ArrendamientosAsync([FromQuery][Required] int tuteladoId, ArrendamientosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<ArrendamientoListItem>>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerArrendamientoAsync(int id, ArrendamientoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<ArrendamientoViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearArrendamientoAsync(CrearArrendamientoRequest request, CrearArrendamientoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarArrendamientoAsync(int id, ArrendamientoViewModel request, ActualizarArrendamientoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarArrendamientoAsync(int id, BorrarArrendamientoHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}