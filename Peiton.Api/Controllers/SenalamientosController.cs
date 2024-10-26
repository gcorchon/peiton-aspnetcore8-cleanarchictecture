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
    public async Task<IActionResult> CrearSenalamientoAsync(GuardarSenalamientoRequest request, CrearEntityHandler<Senalamiento> handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarSenalamientoAsync(int id, GuardarSenalamientoRequest request, ActualizarEntityHandler<Senalamiento> handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }
}