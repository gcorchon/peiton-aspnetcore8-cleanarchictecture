using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.Visitas;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Visitas;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize()]
[PeitonAuthorization(PeitonPermission.InstitucionalVisitas)]
[Route("api/visitas")]
public class VisitasController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> RegistrosEntradaAsync([FromQuery] RegistroEntradaFilter filter, [FromQuery] Pagination pagination, RegistrosEntradaHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<RegistroEntradaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> RegistroEntradaAsync(int id, EntityHandler<RegistroEntrada> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<RegistroEntradaViewModel>(data);
        return Ok(vm);
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearRegistroEntradaAsync(CrearRegistroEntradaRequest request, CrearRegistroEntradaHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarRegistroEntradaAsync(int id, RegistroEntradaViewModel request, ActualizarRegistroEntradaHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarRegistroEntradaAsync(int id, DeleteEntityHandler<RegistroEntrada> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("visitantes")]
    public async Task<IActionResult> ObtenerVisitantesAsync([FromQuery] string query, ObtenerVisitantesHandler handler)
    {
        var data = await handler.HandleAsync(query);
        return Ok(data);
    }

    [HttpGet("sin-salida")]
    public async Task<IActionResult> RegistrosEntradaSinSalidaAsync([FromQuery] Pagination pagination, RegistrosEntradaSinSalidaHandler handler)
    {
        var data = await handler.HandleAsync(pagination);
        var vm = mapper.Map<IEnumerable<RegistroEntradaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpPatch("sin-salida")]
    public async Task<IActionResult> MarcarSalidasAsync(MarcarSalidasRequest request, MarcarSalidasHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }
}