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
using Peiton.Core.Entities;
using Peiton.Core.UseCases.DatosEconomicos;

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
    /*
        [HttpGet("{id:int}/datos-economicos")]
        //[HidePropertiesByRole]
        [AuthorizeTuteladoView]
        public async Task<IActionResult> DatosEconomicosAsync(int id, EntityHandler<Tutelado> handler)
        {
            var data = await handler.HandleAsync(id);
            var vm = mapper.Map<VM.DatosEconomicos.DatosEconomicosViewModel>(data.DatosEconomicos);
            return Ok(vm);
        }

        [HttpPatch("{id:int}/datos-economicos/otros-datos")]
        [AuthorizeTuteladoModify]
        public async Task<IActionResult> ActualizarOtrosDatosDeInteresAsync(int id, [FromBody] string otrosDatos, ActualizarOtrosDatosDeInteresHandler handler)
        {
            await handler.HandleAsync(id, otrosDatos);
            return Accepted();
        }

        [HttpPatch("{id:int}/datos-economicos/derechos")]
        [AuthorizeTuteladoModify]
        public async Task<IActionResult> ActualizarDerechosAsync(int id, [FromBody] string derechos, ActualizarDerechosHandler handler)
        {
            await handler.HandleAsync(id, derechos);
            return Accepted();
        }

        [HttpPatch("{id:int}/datos-economicos/derechos-de-credito")]
        [AuthorizeTuteladoModify]
        public async Task<IActionResult> ActualizarDerechosDeCreditoAsync(int id, [FromBody] string derechosDeCredito, ActualizarDerechosDeCreditoHandler handler)
        {
            await handler.HandleAsync(id, derechosDeCredito);
            return Accepted();
        }

        [HttpPatch("{id:int}/datos-economicos/otros-bienes")]
        [AuthorizeTuteladoModify]
        public async Task<IActionResult> ActualizarOtrosBienesAsync(int id, [FromBody] string otrosBienes, ActualizarOtrosBienesHandler handler)
        {
            await handler.HandleAsync(id, otrosBienes);
            return Accepted();
        }

        [HttpPatch("{id:int}/datos-economicos/exento-irpf")]
        [AuthorizeTuteladoModify]
        public async Task<IActionResult> ActualizarExentoIRPFAsync(int id, [FromBody] bool exentoIRPF, ActualizarExentoIRPFHandler handler)
        {
            await handler.HandleAsync(id, exentoIRPF);
            return Accepted();
        }
    */
    /*    [HttpGet("{id:int}/productos")]
        [AuthorizeTuteladoView]
        public async Task<IActionResult> ProductosAsync(int id, [FromQuery] SueldosPensionesFilter filter, [FromQuery] Pagination pagination, SueldosPensionesHandler handler)
        {
            var data = await handler.HandleAsync(id, filter, pagination);
            var vm = mapper.Map<IEnumerable<SueldoPensionListItem>>(data.Items);
            return this.PaginatedResult(vm, data.Total);
        }
    */
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
