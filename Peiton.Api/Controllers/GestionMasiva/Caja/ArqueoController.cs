using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Core.UseCases.GestionMasiva;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[Route("api/[controller]")]
public class ArqueoController : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> Arqueo([FromQuery] DateTime fecha, ArqueoHandler handler)
    {
        var data = await handler.HandleAsync(fecha);
        return Ok(data);
    }

    [HttpPost("")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> GuardarArqueo([FromQuery] DateTime fecha, [FromBody] ArqueoModel arqueo, GuardarArqueoHandler handler)
    {
        await handler.HandleAsync(fecha, arqueo);
        return Accepted();
    }

}