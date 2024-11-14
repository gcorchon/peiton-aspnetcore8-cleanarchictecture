using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Vehiculos;
using Peiton.Core.UseCases.Vehiculos;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiculosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> VehiculosAsync([FromQuery][Required] int tuteladoId, VehiculosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<VehiculoListItem>>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearVehiculoAsync(CrearVehiculoRequest request, CrearVehiculoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarVehiculoAsync(int id, ActualizarVehiculoRequest request, ActualizarVehiculoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarVehiculoAsync(int id, BorrarVehiculoHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

}
