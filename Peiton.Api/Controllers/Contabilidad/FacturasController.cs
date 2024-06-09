using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Api.RouterConstraints;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.Facturas;
using Peiton.Core.UseCases.Contabilidad.Facturas;
using Peiton.ModelBinders;

namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class FacturasController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [QueryParameterConstraint("ids")]
    public async Task<IActionResult> FacturasPorIds([FromQuery][ModelBinder(BinderType = typeof(StringToIntArrayModelBinder))] int[] ids, FacturasPorIdsHandler handler)
    {
        var facturas = await handler.HandleAsync(ids);
        var viewModel = mapper.Map<IEnumerable<FacturaListItem>>(facturas);
        return Ok(viewModel);
    }

    [HttpGet("")]  
    public async Task<IActionResult> Facturas([FromQuery] FacturasFilter filter, [FromQuery] Pagination pagination, FacturasHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<FacturaListItem>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }

    [HttpGet("pendientes")]
    public async Task<IActionResult> FacturasParaAsociar([FromQuery] FacturasFilter filter, [FromQuery] Pagination pagination, FacturasParaAsociarHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<FacturaListItem>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }
}
