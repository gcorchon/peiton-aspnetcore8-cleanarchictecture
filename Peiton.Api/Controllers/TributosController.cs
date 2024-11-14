using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Tributos;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Tributos;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TributosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> TributosAsync([FromQuery][Required] int tuteladoId, TributosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<TributoListItem>>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerTributoAsync(int id, TributoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<TributoViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearTributoAsync(CrearTributoRequest request, CrearTributoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarTributoAsync(int id, TributoViewModel request, ActualizarTributoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarTributoAsync(int id, BorrarTributoHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}