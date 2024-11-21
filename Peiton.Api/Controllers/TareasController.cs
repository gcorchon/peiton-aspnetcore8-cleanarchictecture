using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Tareas;
using Peiton.Core.Entities;
using Peiton.Contracts.Tareas;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareasController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> TareaAsync([FromQuery][Required] int tuteladoId, [FromQuery] TareasFilter filter, [FromQuery] Pagination pagination, TareasHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, filter, pagination);
        var vm = mapper.Map<IEnumerable<TareaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerTareaAsync(int id, TareaHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<TareaViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearTareaAsync(CrearTareaRequest request, CrearTareaHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarTareaAsync(int id, ActualizarTareaRequest request, ActualizarTareaHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpPatch("{id:int}/cerrar")]
    public async Task<IActionResult> CerrarTareaAsync(int id, CerrarTareaHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarTareaAsync(int id, DeleteEntityHandler<Tarea> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("{id:int}/exportar")]
    public async Task<IActionResult> ExportarTareaAsync(int id, ExportarTareaHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data, "application/pdf", "tarea.pdf");
    }

    [HttpPost("documentos")]
    public async Task<IActionResult> GuardarDocumentoAsync([FromForm] IFormFile file, GuardarDocumentoHandler handler)
    {
        var fileName = await handler.HandleAsync(file);
        return Ok(fileName);
    }

    [HttpGet("documentos")]
    public async Task<IActionResult> DescargarDocumentoAsync([FromQuery] string path, DescargarDocumentoHandler handler)
    {
        var data = await handler.HandleAsync(path);
        return File(data.Data, data.MimeType, data.FileName);
    }
}