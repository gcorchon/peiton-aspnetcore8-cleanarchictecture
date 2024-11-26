using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Contracts.Enums;
using Peiton.Core.UseCases.Cajas;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CajaController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> MovimientosCajaAsync([FromQuery] CajaFilter filter, [FromQuery] Pagination pagination, TipoMovimiento metodo, MovimientosCajaHandler handler)
    {
        var data = await handler.HandleAsync(metodo, filter, pagination);
        var vm = mapper.Map<IEnumerable<CajaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> MovimientoCajaAsync(int id, MovimientoCajaHandler handler)
    {
        var vm = await handler.HandleAsync(id);
        return Ok(vm);
    }

    [HttpDelete("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> EliminarMovimientoCajaAsync(int id, EliminarMovimientoCajaHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpDelete("{id:int}/deshacer-pago")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> DeshacerMovimientoCajaAsync(int id, DeshacerMovimientoCajaHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("tutelado")]
    public async Task<IActionResult> CajaAsync([FromQuery][Required] int tuteladoId, [FromQuery] CajaTuteladoFilter filter, [FromQuery] Pagination pagination, CajaTuteladoHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, filter, pagination);
        var vm = mapper.Map<IEnumerable<CajaTuteladoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("tutelado/exportar")]
    public async Task<IActionResult> ExportaCajaAsync([FromQuery][Required] int tuteladoId, [FromQuery] CajaTuteladoFilter filter, ExportarCajaTuteladoHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, filter);
        return File(data, MimeTypeHelper.Excel, "caja.xlsx");
    }
}