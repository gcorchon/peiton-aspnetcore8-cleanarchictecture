using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Contracts.Tutelados;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Cajas;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.GestionIndividual;
using Peiton.Core.UseCases.Tutelados;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TuteladosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> TuteladosAsync([FromQuery] TuteladosFilter filter, [FromQuery] Pagination pagination, TuteladosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<TuteladoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}/datos-generales")]
    [HidePropertiesByRole]
    public async Task<IActionResult> DatosGeneralesAsync(int id, TuteladoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<DatosGeneralesViewModel>(data);
        return Ok(vm);
    }

    [HttpGet("{id}/historico-movimientos-caja")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> HistoricoMovimientosCajaAsync([FromQuery] HistoricoMovimientosFilter filter, [FromQuery] Pagination pagination, int id, HistoricoMovimientosCajaHandler handler)
    {
        var data = await handler.HandleAsync(id, filter, pagination);
        var vm = mapper.Map<IEnumerable<HistoricoMovimientoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id}/entidades-financieras-con-cuentas-de-robot-activas")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> CuentasDeRobotActivasAsync(int id, CuentasDeRobotHandler handler)
    {
        var vm = await handler.HandleAsync(id);
        return Ok(vm);
    }

    [HttpGet("por-nombre")]
    public async Task<IActionResult> TuteladosPorNombreAsync([FromQuery] string query, ObtenerTuteladosPorNombreHandler handler)
    {
        var data = await handler.HandleAsync(query);
        var vm = mapper.Map<IEnumerable<ListItem>>(data);
        return Ok(vm);
    }


}
