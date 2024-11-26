using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Core.UseCases.Cajas;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
[Route("api/[controller]")]
public class ReintegrosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> ReintegrosAsync(ReintegrosHandler handler)
    {
        var data = await handler.HandleAsync();
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> GuardarReintegrosAsync([FromBody] TuteladoReintegroSerializado[] data, GuardarReintegrosHandler handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPost("encajonar")]
    public async Task<IActionResult> EncajonarReintegrosAsync(EncajonarReintegrosHandler handler)
    {
        await handler.HandleAsync();
        return Accepted();
    }

    [HttpPost("documento")]
    public async Task<IActionResult> DocumentoReintegrosAsync([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta, GenerarListadoReintegrosHandler handler)
    {
        await handler.HandleAsync(fechaDesde, fechaHasta);
        return Ok();
    }

    [HttpGet("exportar")]
    public async Task<IActionResult> ExportarReintegrosAsync(ExportarReintegrosHandler handler)
    {
        var data = await handler.HandleAsync();
        return File(data, MimeTypeHelper.Excel, "reintegros.xlsx");
    }

    [HttpGet("tutelados")]
    public async Task<IActionResult> TuteladosAsync([FromQuery] string text, TuteladosReintegrosHandler handler)
    {
        var data = await handler.HandleAsync(text);
        var vm = mapper.Map<IEnumerable<TuteladoReintegro>>(data);
        return Ok(vm);
    }
}
