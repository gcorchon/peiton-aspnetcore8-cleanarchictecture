using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Seguimientos;
using Peiton.Core.UseCases.Seguimientos;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeguimientoController(IMapper mapper) : ControllerBase
{

    [HttpGet()]
    public async Task<IActionResult> SeguimientoAsync([FromQuery][Required] int tuteladoId, [FromQuery] SeguimientosFilter filter, [FromQuery] Pagination pagination, SeguimientosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, filter, pagination);
        var vm = mapper.Map<IEnumerable<SeguimientoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerSeguimientoAsync(int id, SeguimientoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<SeguimientoViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearSeguimientoAsync(CrearSeguimientoRequest request, CrearSeguimientoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarSeguimientoAsync(int id, ActualizarSeguimientoRequest request, ActualizarSeguimientoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarSeguimientoAsync(int id, DeleteEntityHandler<Agenda> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("{id:int}/exportar")]
    public async Task<IActionResult> ExportarSeguimientoAsync(int id, ExportarSeguimientoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data, "application/pdf", "seguimiento.pdf");
    }

    [HttpGet("exportar")]
    public async Task<IActionResult> ExportarSeguimientosTuteladoAsync([FromQuery][Required] int tuteladoId, [FromQuery] SeguimientosFilter filter, ExportarSeguimientosTuteladoHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, filter);
        return File(data, "application/pdf", "seguimientos.pdf");
    }

    [HttpGet("exportar-masiva")]
    public async Task<IActionResult> ExportarSeguimientoMasivaAsync([FromQuery] ExportarSeguimientosMasivaRequest request, ExportarSeguimientoMasivaHandler handler)
    {
        var data = await handler.HandleAsync(request);
        return File(data, "application/pdf", "seguimientos.pdf");
    }
}