using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Contracts.Facturas;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.UseCases.Common;
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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Asiento(int id, EntityHandler<Asiento> handler)
    {
        try
        {
            var entity = await handler.HandleAsync(id);
            var vm = mapper.Map<AsientoViewModel>(entity);
            return Ok(vm);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearAsiento(AsientoSaveRequest data, CrearAsientoHandler handler)
    {
        try {
            await handler.HandleAsync(data);
            return Accepted();
        } catch(ArgumentException) {
            return BadRequest();
        }
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarAsiento(int id, AsientoSaveRequest data, ActualizarAsientoHandler handler)
    {
        try{
            await handler.HandleAsync(id, data);
            return Accepted();
        } catch(NotFoundException) {
            return NotFound();
        } catch(ArgumentException) {
            return BadRequest();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarAsiento(int id, DeleteEntityHandler<Asiento> handler)
    {
        try{
            await handler.HandleAsync(id);
            return Accepted();
        } catch(NotFoundException) {
            return NotFound();
        } 
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
