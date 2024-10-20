using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.Quejas;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Quejas;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.InstitucionalQuejas)]
[Route("api/[controller]")]
public class QuejasController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> QuejasAsync([FromQuery] QuejasFilter filter, [FromQuery] Pagination pagination, QuejasHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<QuejaViewModel>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerQuejaAsync(int id, EntityHandler<Queja> handler)
    {
        var entity = await handler.HandleAsync(id);
        var vm = mapper.Map<QuejaViewModel>(entity);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearQuejaAsync(GuardarQuejaRequest data, CrearrQuejaHandler handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarQuejaAsync(int id, [FromBody] GuardarQuejaRequest data, ActualizarQuejaHandler handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    [PeitonAuthorization(PeitonPermission.InstitucionalQuejasBorrar)]
    public async Task<IActionResult> BorrarQuejaAsync(int id, DeleteEntityHandler<Queja> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPost("documentos")]
    public async Task<IActionResult> GuardarDocumentoAsync([FromForm] IFormFile file, GuardarDocumentoHandler handler)
    {
        var fileName = await handler.HandleAsync(file);
        return Ok(fileName);
    }

    [HttpGet("documentos")]
    public async Task<IActionResult> DescargarDocumentoAsync([FromQuery] string path)
    {
        var filePath = FilePathValidator.CombineSafe("App_Data/Quejas", path);

        if (!System.IO.File.Exists(filePath)) return NotFound();

        var content = await System.IO.File.ReadAllBytesAsync(filePath);
        return File(content, MimeTypeHelper.GetMimeType(filePath), path.Substring(path.IndexOf("_") + 1));
    }
}
