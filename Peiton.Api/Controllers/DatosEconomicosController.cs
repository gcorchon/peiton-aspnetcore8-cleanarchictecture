using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.DatosEconomicos;
using VM = Peiton.Contracts;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.GestionIndividualDatosEconomicos)]
[Route("api/tutelados/{id:int}/datos-economicos")]
public class DatosEconomicosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    //[HidePropertiesByRole]
    [AuthorizeTuteladoView]
    public async Task<IActionResult> DatosEconomicosAsync(int id, EntityHandler<Tutelado> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<VM.DatosEconomicos.DatosEconomicosViewModel>(data.DatosEconomicos);
        return Ok(vm);
    }

    [HttpPatch("otros-datos")]
    [AuthorizeTuteladoModify]
    public async Task<IActionResult> ActualizarOtrosDatosDeInteresAsync(int id, [FromBody] string otrosDatos, ActualizarOtrosDatosDeInteresHandler handler)
    {
        await handler.HandleAsync(id, otrosDatos);
        return Accepted();
    }

    [HttpPatch("derechos")]
    [AuthorizeTuteladoModify]
    public async Task<IActionResult> ActualizarDerechosAsync(int id, [FromBody] string derechos, ActualizarDerechosHandler handler)
    {
        await handler.HandleAsync(id, derechos);
        return Accepted();
    }

    [HttpPatch("derechos-de-credito")]
    [AuthorizeTuteladoModify]
    public async Task<IActionResult> ActualizarDerechosDeCreditoAsync(int id, [FromBody] string derechosDeCredito, ActualizarDerechosDeCreditoHandler handler)
    {
        await handler.HandleAsync(id, derechosDeCredito);
        return Accepted();
    }

    [HttpPatch("otros-bienes")]
    [AuthorizeTuteladoModify]
    public async Task<IActionResult> ActualizarOtrosBienesAsync(int id, [FromBody] string otrosBienes, ActualizarOtrosBienesHandler handler)
    {
        await handler.HandleAsync(id, otrosBienes);
        return Accepted();
    }

    [HttpPatch("otras-deudas")]
    [AuthorizeTuteladoModify]
    public async Task<IActionResult> ActualizarOtrasDeudasAsync(int id, [FromBody] string otrasDeudas, ActualizarOtrasDeudasHandler handler)
    {
        await handler.HandleAsync(id, otrasDeudas);
        return Accepted();
    }

    [HttpPatch("exento-irpf")]
    [AuthorizeTuteladoModify]
    public async Task<IActionResult> ActualizarExentoIRPFAsync(int id, [FromBody] bool exentoIRPF, ActualizarExentoIRPFHandler handler)
    {
        await handler.HandleAsync(id, exentoIRPF);
        return Accepted();
    }
}