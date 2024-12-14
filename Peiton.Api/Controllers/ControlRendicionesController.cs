using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.ControlRendiciones;
using Peiton.Core.UseCases.ControlRendiciones;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/control-rendiciones")]
public class ControlRendicionesController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> ControlRendicionAsync([FromQuery][Required] int tuteladoId, ControlRendicionesHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<ControlRendicionListItem>>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerControlRendicionAsync(int id, ControlRendicionHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<ControlRendicionViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearControlRendicionAsync(CrearControlRendicionRequest request, CrearControlRendicionHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarControlRendicionAsync(int id, ActualizarControlRendicionRequest request, ActualizarControlRendicionHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarControlRendicionAsync(int id, BorrarControlRendicionHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    //Nota para el futuro: La retribución continuada se gestiona en el controlador de Tutelado.

}