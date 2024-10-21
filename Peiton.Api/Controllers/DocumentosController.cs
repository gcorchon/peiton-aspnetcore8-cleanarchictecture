using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Documentos;
using Peiton.Core.UseCases.Documentos;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize()]
[PeitonAuthorization(PeitonPermission.InstitucionalDocumentos)]
[Route("api/documentos")]
public class DocumentosController : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> DocumentosAsync(DocumentosHandler handler)
    {
        var data = await handler.HandleAsync();
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearDocumentoAsync([FromForm] GuardarDocumentoRequest request, CrearDocumentoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarDocumentoAsync(int id, [FromForm] GuardarDocumentoRequest request, ActualizarDocumentoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpGet("categorias")]
    public async Task<IActionResult> CategoriasAsync(CategoriaDocumentosHandler handler)
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