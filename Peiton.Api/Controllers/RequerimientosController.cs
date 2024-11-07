using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Requerimientos;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Requerimientos;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequerimientosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> RequerimientosAsync([FromQuery] RequerimientosFilter filter, [FromQuery] Pagination pagination, RequerimientosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<RequerimientoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerRequerimientoAsync(int id, EntityHandler<Requerimiento> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<RequerimientoViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearRequerimientoAsync(GuardarRequerimientoRequest request, CrearRequerimientoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarRequerimientoAsync(int id, GuardarRequerimientoRequest request, ActualizarRequerimientoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarRequerimientoAsync(int id, DeleteEntityHandler<Requerimiento> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}