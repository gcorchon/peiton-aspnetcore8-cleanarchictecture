using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Core.UseCases.GestionMasiva.CajaMasiva;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
[Route("api/[controller]")]
public class ReintegrosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Reintegros(ReintegrosHandler handler)
    {
        var data = await handler.HandleAsync();
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> GuardarReintegros([FromBody] TuteladoReintegroSerializado[] data, GuardarReintegrosHandler handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPost("encajonar")]
    public async Task<IActionResult> EncajonarReintegros(EncajonarReintegrosHandler handler)
    {
        await handler.HandleAsync();
        return Accepted();
    }

    [HttpPost("documento")]
    public async Task<IActionResult> DocumentoReintegros([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta, GenerarListadoReintegrosHandler handler)
    {
        await handler.HandleAsync(fechaDesde, fechaHasta);
        return Ok();
    }

    [HttpGet("tutelados")]
    public async Task<IActionResult> Tutelados([FromQuery] string text, TuteladosReintegrosHandler handler)
    {
        var data = await handler.HandleAsync(text);
        var vm = mapper.Map<IEnumerable<TuteladoReintegro>>(data);
        return Ok(vm);
    }
}
