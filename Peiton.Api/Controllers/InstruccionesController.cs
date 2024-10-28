using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Instrucciones;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Instrucciones;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize()]
[PeitonAuthorization(PeitonPermission.InstitucionalProcesos)]
[Route("api/instrucciones")]
public class InstruccionesController : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> InstruccionesAsync(InstruccionesHandler handler)
    {
        var data = await handler.HandleAsync();
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearInstruccionAsync([FromForm] GuardarInstruccionRequest request, CrearInstruccionHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarInstruccionAsync(int id, [FromForm] GuardarInstruccionRequest request, ActualizarInstruccionHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarDocumentoAsync(int id, DeleteEntityHandler<Instruccion> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("categorias")]
    public async Task<IActionResult> CategoriasAsync(CategoriaInstruccionesHandler handler)
    {
        var data = await handler.HandleAsync();
        return Ok(data);
    }

    [HttpGet("{id:int}/download")]
    public async Task<IActionResult> DescargarDocumentoAsync(int id, DescargarDocumentoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data.Content, MimeTypeHelper.GetMimeType(data.FileName), data.FileName);
    }
}