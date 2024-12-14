using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.ControlInventarios;
using Peiton.Core.UseCases.ControlInventarios;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/control-inventarios")]
public class ControlInventariosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> ControlInventariosAsync([FromQuery][Required] int tuteladoId, ControlInventariosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<ControlInventarioListItem>>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerControlInventarioAsync(int id, ControlInventarioHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<ControlInventarioViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearControlInventarioAsync(CrearControlInventarioRequest request, CrearControlInventarioHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarControlInventarioAsync(int id, ActualizarControlInventarioRequest request, ActualizarControlInventarioHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarControlInventarioAsync(int id, BorrarControlInventarioHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }


}