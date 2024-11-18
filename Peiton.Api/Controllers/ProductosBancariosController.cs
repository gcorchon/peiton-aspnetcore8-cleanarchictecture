using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.UseCases.ProductosBancarios;
using Peiton.Contracts.ProductosBancarios;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/productos-bancarios")]
public class ProductosBancariosController : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> ProductosBancariosAsync([FromQuery][Required] int tuteladoId, ProductosBancariosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        return Ok(data);
    }

    [HttpGet("{id:int}/{tipo}")]
    public async Task<IActionResult> ProductoBancarioAsync(int id, string tipo, ProductoBancarioHandler handler)
    {
        var data = await handler.HandleAsync(id, tipo);
        return Ok(data);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearProductoBancarioAsync(CrearProductoBancarioRequest request, CrearProductoBancarioHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}/manual")]
    public async Task<IActionResult> ActualizarProductoBancarioAsync(int id, ProductoBancarioViewModel request, ActualizarProductoBancarioManualHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpPatch("{id:int}/robot")]
    public async Task<IActionResult> ActualizarProductoBancarioRobotAsync(int id, ActualizarProductoBancarioRobotRequest request, ActualizarProductoBancarioRobotHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }
}