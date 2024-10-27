using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Senalamientos;
using Peiton.Contracts.Senalamientos;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.InstitucionalSenalamientos)]
[Route("api/[controller]")]
public class SenalamientosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> SenalamientosAsync([FromQuery] SenalamientosFillter filter, SenalamientosHandler handler)
    {
        var data = await handler.HandleAsync(filter);
        var vm = mapper.Map<IEnumerable<SenalamientoListItem>>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerSenalamientoAsync(int id, EntityHandler<Senalamiento> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<SenalamientoViewModel>(data);
        return Ok(vm);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarSenalamientoAsync(int id, DeleteEntityHandler<Senalamiento> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPost()]
    public async Task<IActionResult> CrearSenalamientoAsync(GuardarSenalamientoRequest request, CrearSenalamientoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarSenalamientoAsync(int id, GuardarSenalamientoRequest request, ActualizarSenalamientoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpGet("profesionales")]
    public async Task<IActionResult> ProfesionalesAsync([FromQuery] string query, ProfesionalesHandler handler)
    {
        var data = await handler.HandleAsync(query);
        return Ok(data);
    }

    [HttpGet("abogados")]
    public async Task<IActionResult> AbogadosAsync([FromQuery][Required]int tuteladoId, [FromQuery][Required] DateTime fecha, [FromQuery][Required] int juzgadoId, [FromQuery] int? senalamientoId, ObtenerAbogadosParaSenalamientoHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, fecha, juzgadoId, senalamientoId);
        return Ok(data);
    }

}