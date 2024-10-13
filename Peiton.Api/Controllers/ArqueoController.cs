using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Core.UseCases.Arqueos;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArqueoController : ControllerBase
{
    [HttpGet("{fecha:datetime}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> ArqueoAsync(DateTime fecha, ArqueoHandler handler)
    {
        var data = await handler.HandleAsync(fecha);
        return Ok(data);
    }

    [HttpPost("{fecha:datetime}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> GuardarArqueoAsync(DateTime fecha, [FromBody] ArqueoModel arqueo, GuardarArqueoHandler handler)
    {
        await handler.HandleAsync(fecha, arqueo);
        return Accepted();
    }

    [HttpGet("{fecha:datetime}/documento")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> DocumentoArqueoAsync(DateTime fecha, DocumentoArqueoHandler handler)
    {
        await handler.HandleAsync(fecha);
        return Accepted();
    }
}