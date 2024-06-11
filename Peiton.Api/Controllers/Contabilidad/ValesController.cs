using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.Vales;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Contabilidad.Vales;

namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class ValesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Vales([FromQuery] ValesFilter filter, [FromQuery] Pagination pagination, ValesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<ValeListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Vale(int id, EntityHandler<Vale> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<ValeViewModel>(data);
        return Ok(vm);
    }

    [HttpPost("")]
    public async Task<IActionResult> GuardarVale([FromBody] GuardarValeRequest data, GuardarValeHandler handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarVale(int id, [FromBody] ActualizarValeRequest data, ActualizarValeHandler handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarVale(int id, DeleteEntityHandler<Vale> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}