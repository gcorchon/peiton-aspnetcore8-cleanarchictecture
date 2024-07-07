using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Contracts.Facturas;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Asientos;
using Peiton.Core.UseCases.Common;


namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class AsientosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    [PeitonAuthorization(PeitonPermission.ContabilidadAsientosYSaldosAsientos)]
    public async Task<IActionResult> AsientosAsync([FromQuery] AsientosFilter filter, [FromQuery] Pagination pagination, AsientosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<AsientoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> AsientoAsync(int id, EntityHandler<Asiento> handler)
    {
        var entity = await handler.HandleAsync(id);
        var vm = mapper.Map<AsientoViewModel>(entity);
        return Ok(vm);
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearAsientoAsync(AsientoSaveRequest data, CrearAsientoHandler handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarAsientoAsync(int id, AsientoSaveRequest data, ActualizarAsientoHandler handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();

    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarAsientoAsync(int id, DeleteEntityHandler<Asiento> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("{id:int}/facturas")]
    [PeitonAuthorization(PeitonPermission.ContabilidadNuevosMovimientos)]
    public async Task<IActionResult> FacturasAsync(int id, FacturasHandler handler)
    {
        var asiento = await handler.HandleAsync(id);
        var vm = mapper.Map<IEnumerable<FacturaListItem>>(asiento.Facturas);
        return Ok(vm);
    }

    [HttpGet("huerfanos")]
    [PeitonAuthorization(PeitonPermission.ContabilidadNuevosMovimientos)]
    public async Task<IActionResult> AsientosHuerfanosAsync([FromQuery] AsientosHuerfanosFilter filter, [FromQuery] Pagination pagination, AsientosHuerfanosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<AsientoHuerfanoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

}
