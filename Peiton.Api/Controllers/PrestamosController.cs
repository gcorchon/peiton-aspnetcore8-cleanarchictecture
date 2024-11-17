using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.UseCases.Prestamos;
using Peiton.Contracts.Prestamos;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrestamosController : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> PrestamosAsync([FromQuery][Required] int tuteladoId, PrestamosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        return Ok(data);
    }

    [HttpGet("{id:int}/{tipo}")]
    public async Task<IActionResult> PrestamoAsync(int id, string tipo, PrestamoHandler handler)
    {
        var data = await handler.HandleAsync(id, tipo);
        return Ok(data);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearPrestamoAsync(CrearPrestamoRequest request, CrearPrestamoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}/manual")]
    public async Task<IActionResult> ActualizarPrestamoAsync(int id, PrestamoViewModel request, ActualizarPrestamoManualHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpPatch("{id:int}/robot")]
    public async Task<IActionResult> ActualizarRobotAsync(int id, ActualizarPrestamoRobotRequest request, ActualizarPrestamoRobotHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }
}