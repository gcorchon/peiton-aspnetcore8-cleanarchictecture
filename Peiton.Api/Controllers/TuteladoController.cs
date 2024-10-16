using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Contracts.EntidadFinanciera;
using Peiton.Core.UseCases.Cajas;
using Peiton.Core.UseCases.GestionIndividual;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TuteladoController(IMapper mapper) : ControllerBase
{
    [HttpGet("{id}/historico-movimientos-caja")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> HistoricoMovimientosCaja([FromQuery] HistoricoMovimientosFilter filter, [FromQuery] Pagination pagination, int id, HistoricoMovimientosCajaHandler handler)
    {
        var data = await handler.HandleAsync(id, filter, pagination);
        var vm = mapper.Map<IEnumerable<HistoricoMovimientoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id}/entidades-financieras-con-cuentas-de-robot-activas")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> CuentasDeRobotActivas(int id, CuentasDeRobotHandler handler)
    {
        var vm = await handler.HandleAsync(id);
        return Ok(vm);
    }
}
