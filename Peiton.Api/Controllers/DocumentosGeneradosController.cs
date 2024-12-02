using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.DocumentosGenerados;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/documentos-generados")]
public class DocumentosGeneradosController : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> DocumentosGeneradosAsync(DocumentosGeneradosHandler handler)
    {
        var data = await handler.HandleAsync();
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GenerarDocumentoAsync(int id, [FromQuery][Required] int tuteladoId, GenerarDocumentHandler handler)
    {
        var data = await handler.HandleAsync(id, tuteladoId);
        return File(data.Data, data.MimeType, data.FileName);
    }
}