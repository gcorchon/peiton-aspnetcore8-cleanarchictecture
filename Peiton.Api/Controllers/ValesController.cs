using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.Vales;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Vales;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.ContabilidadVales)]
    public async Task<IActionResult> ValesAsync([FromQuery] ValesFilter filter, [FromQuery] Pagination pagination, ValesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<ValeListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    [PeitonAuthorization(PeitonPermission.ContabilidadVales)]
    public async Task<IActionResult> ValeAsync(int id, EntityHandler<Vale> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<ValeViewModel>(data);
        return Ok(vm);
    }

    [HttpPost("")]
    [PeitonAuthorization(PeitonPermission.HomeVales)]
    public async Task<IActionResult> GuardarValeAsync([FromBody] GuardarValeRequest data, GuardarValeHandler handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    [PeitonAuthorization(PeitonPermission.ContabilidadVales)]
    public async Task<IActionResult> ActualizarValeAsync(int id, [FromBody] ActualizarValeRequest data, ActualizarValeHandler handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    [PeitonAuthorization(PeitonPermission.ContabilidadVales)]
    public async Task<IActionResult> BorrarValeAsync(int id, DeleteEntityHandler<Vale> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPost("files")]
    [PeitonAuthorization(PeitonPermission.HomeVales)]
    public async Task<IActionResult> UploadFileAsync(IFormFile file, UploadValeHandler handler)
    {
        var data = await handler.HandleAsync(file);
        return Ok(data);
    }

    [HttpGet("{id:int}/files")]
    [PeitonAuthorization(PeitonPermission.ContabilidadVales)]
    public async Task<IActionResult> DownloadFileAsync(int id, DownloadValeHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data, "application/zip", "vale.zip");
    }
}