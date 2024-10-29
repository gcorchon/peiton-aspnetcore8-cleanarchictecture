using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Extensions;
using Peiton.Contracts.Common;
using Peiton.Contracts.Sucursales;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Sucursales;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SucursalesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> SucursalesAsync([FromQuery] SucursalesFilter filter, [FromQuery] Pagination pagination, SucursalesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<SucursalListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> SucursalAsync(int id, EntityHandler<Sucursal> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<SucursalViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarSucursalAsync(int id, SucursalViewModel request, ActualizarEntityHandler<Sucursal> handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearSucursalAsync(SucursalViewModel request, CrearEntityHandler<Sucursal> handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarSucursalAsync(int id, DeleteEntityHandler<Sucursal> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}