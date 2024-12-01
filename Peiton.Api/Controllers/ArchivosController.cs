using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Archivos;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Archivos;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize()]
[Route("api/archivos")]
public class ArchivosController : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> ArchivosAsync([FromQuery][Required] int tuteladoId, ArchivosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearArchivoAsync([FromForm] CrearArchivoRequest request, CrearArchivoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarArchivoAsync(int id, [FromBody] ActualizarArchivoRequest request, ActualizarArchivoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarArchivoAsync(int id, BorrarArchivoHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("{id:int}/download")]
    public async Task<IActionResult> DescargarArchivoAsync(int id, DescargarArchivoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data.Data, data.MimeType, data.FileName);
    }
}