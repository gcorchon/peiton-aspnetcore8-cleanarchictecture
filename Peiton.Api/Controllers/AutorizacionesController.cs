using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Core.UseCases.Autorizaciones;
using System.ComponentModel.DataAnnotations;
using Peiton.Contracts.Autorizaciones;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutorizacionesController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> AutorizacionesAsync([FromQuery][Required] int tuteladoId, AutorizacionesHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<AutorizacionListItem>>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearAutorizacionAsync(CrearAutorizacionRequest request, CrearAutorizacionHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarAutorizacionAsync(int id, ActualizarAutorizacionRequest request, ActualizarAutorizacionHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarAutorizacionAsync(int id, BorrarAutorizacionHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}