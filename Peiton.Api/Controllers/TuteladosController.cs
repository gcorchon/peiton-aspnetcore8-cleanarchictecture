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
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Seguimientos;
using Peiton.Core.Entities;
using Peiton.Contracts.Seguimientos;
using Peiton.Core.UseCases.ProductosBancarios;


namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class TuteladosController(IMapper mapper) : ControllerBase
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
    [AuthorizeTuteladoView]
    public async Task<IActionResult> DatosGeneralesAsync(int id, EntityHandler<Tutelado> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<VM.Tutelados.DatosGeneralesViewModel>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}/datos-juridicos")]
    [AuthorizeTuteladoView]
    public async Task<IActionResult> DatosJuridicosAsync(int id, EntityHandler<Tutelado> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<VM.DatosJuridicos.DatosJuridicosViewModel>(data.DatosJuridicos);
        return Ok(vm);
    }

    [HttpGet("{id:int}/datos-sociales")]
    [AuthorizeTuteladoView]
    public async Task<IActionResult> DatosSocialesAsync(int id, EntityHandler<Tutelado> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<VM.DatosSociales.DatosSocialesViewModel>(data.DatosSociales);
        return Ok(vm);
    }

    [HttpGet("{id:int}/equipo")]
    [AuthorizeTuteladoView]
    public async Task<IActionResult> EquipoAsync(int id, EquipoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return Ok(data);
    }

    [HttpGet("{id:int}/tareas-seguimiento")]
    [AuthorizeTuteladoView]
    public async Task<IActionResult> TareasSeguimientoAsync(int id, EntityHandler<Tutelado> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<IEnumerable<VM.Seguimientos.TareaAgendaViewModel>>(data.TareasAgenda.OrderBy(t => t.Orden));
        return Ok(vm);
    }

    [HttpPost("{id:int}/tareas-seguimiento")]
    [AuthorizeTuteladoModify]
    public async Task<IActionResult> GuardarTareasSeguimientoAsync(int id, [FromBody] TareaAgendaViewModel[] request, GuardarTareasSeguimientoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpGet("{id:int}/posicion-global")]
    public async Task<IActionResult> PosicionGlobalAsync(int id, PosicionGlobalHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return Ok(data);
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
