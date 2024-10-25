using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Procesos;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Procesos;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize()]
[PeitonAuthorization(PeitonPermission.InstitucionalProcesos)]
[Route("api/procesos")]
public class ProcesosController : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> ProcesosAsync(ProcesosHandler handler)
    {
        var data = await handler.HandleAsync();
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearProcesoAsync([FromForm] GuardarProcesoRequest request, CrearProcesoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarProcesoAsync(int id, [FromForm] GuardarProcesoRequest request, ActualizarProcesoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarDocumentoAsync(int id, DeleteEntityHandler<Proceso> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("categorias")]
    public async Task<IActionResult> CategoriasAsync(CategoriaProcesosHandler handler)
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