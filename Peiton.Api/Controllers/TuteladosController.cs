using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using VM = Peiton.Contracts;
using Peiton.Contracts.Common;
using Peiton.Core.UseCases.Cajas;
using Peiton.Core.UseCases.GestionIndividual;
using Peiton.Core.UseCases.Tutelados;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TuteladosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> TuteladosAsync([FromQuery] VM.Tutelados.TuteladosFilter filter, [FromQuery] Pagination pagination, TuteladosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<VM.Tutelados.TuteladoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}/datos-generales")]
    [HidePropertiesByRole]
    public async Task<IActionResult> DatosGeneralesAsync(int id, TuteladoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<VM.Tutelados.DatosGeneralesViewModel>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}/datos-juridicos")]
    //[HidePropertiesByRole]
    public async Task<IActionResult> DatosJuridicosAsync(int id, TuteladoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<VM.DatosJuridicos.DatosJuridicosViewModel>(data.DatosJuridicos);
        return Ok(vm);
    }

    [HttpGet("{id:int}/datos-sociales")]
    //[HidePropertiesByRole]
    public async Task<IActionResult> DatosSocialesAsync(int id, TuteladoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<VM.DatosSociales.DatosSocialesViewModel>(data.DatosSociales);
        return Ok(vm);
    }

    [HttpGet("{id}/historico-movimientos-caja")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> HistoricoMovimientosCajaAsync([FromQuery] VM.Caja.HistoricoMovimientosFilter filter, [FromQuery] Pagination pagination, int id, HistoricoMovimientosCajaHandler handler)
    {
        var data = await handler.HandleAsync(id, filter, pagination);
        var vm = mapper.Map<IEnumerable<VM.Caja.HistoricoMovimientoListItem>>(data.Items);
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
        var vm = mapper.Map<IEnumerable<VM.Common.ListItem>>(data);
        return Ok(vm);
    }


}
