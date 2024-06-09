using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Contracts.Facturas;
using Peiton.Core.UseCases.Contabilidad.Asientos;


namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class AsientosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    [PeitonAuthorization(PeitonPermission.ContabilidadAsientosYSaldosAsientos)]
    public async Task<IActionResult> Asientos([FromQuery] AsientosFilter filter, [FromQuery] Pagination pagination, AsientosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<AsientoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }


    [HttpGet("{id:int}/facturas")]
    [PeitonAuthorization(PeitonPermission.ContabilidadNuevosMovimientos)]
    public async Task<IActionResult> Facturas(int id, FacturasHandler handler)
    {
        var asiento = await handler.HandleAsync(id);
        if (asiento == null) return NotFound();
        var vm = mapper.Map<IEnumerable<FacturaListItem>>(asiento.Facturas);
        return Ok(vm);
    }

    [HttpGet("huerfanos")]
    [PeitonAuthorization(PeitonPermission.ContabilidadNuevosMovimientos)]
    public async Task<IActionResult> AsientosHuerfanos([FromQuery] AsientosHuerfanosFilter filter, [FromQuery] Pagination pagination, AsientosHuerfanosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<AsientoHuerfanoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

}
