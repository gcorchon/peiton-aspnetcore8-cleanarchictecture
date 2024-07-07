using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Api.RouterConstraints;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.Facturas;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Facturas;
using Peiton.ModelBinders;

namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class FacturasController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [QueryParameterConstraint("ids")]
    public async Task<IActionResult> FacturasPorIdsAsync([FromQuery][ModelBinder(BinderType = typeof(StringToIntArrayModelBinder))] int[] ids, FacturasPorIdsHandler handler)
    {
        var facturas = await handler.HandleAsync(ids);
        var viewModel = mapper.Map<IEnumerable<FacturaListItem>>(facturas);
        return Ok(viewModel);
    }

    [HttpGet("")]
    public async Task<IActionResult> FacturasAsync([FromQuery] FacturasFilter filter, [FromQuery] Pagination pagination, FacturasHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<FacturaListItem>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> FacturaAsync(int id, EntityHandler<Factura> handler)
    {
        var data = await handler.HandleAsync(id);
        var viewModel = mapper.Map<FacturaViewModel>(data);
        return Ok(viewModel);
    }

    [HttpPost("")]
    public async Task<IActionResult> CrearFacturaAsync(int id, [FromBody] GuardarFacturaRequest request, CrearFacturaHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarFacturaAsync(int id, [FromBody] GuardarFacturaRequest request, ActualizarFacturaHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarFacturaAsync(int id, DeleteEntityHandler<Factura> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("pendientes")]
    public async Task<IActionResult> FacturasParaAsociarAsync([FromQuery] FacturasFilter filter, [FromQuery] Pagination pagination, FacturasParaAsociarHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<FacturaListItem>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }
}
