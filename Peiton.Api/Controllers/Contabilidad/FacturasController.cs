using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
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
    public async Task<IActionResult> Facturas([FromQuery][ModelBinder(BinderType = typeof(StringToIntArrayModelBinder))] int[] ids, FacturasHandler handler)
    {
        var facturas = await handler.HandleAsync(ids);
        var viewModel = mapper.Map<IEnumerable<FacturaListItem>>(facturas);
        return Ok(viewModel);
    }

    [HttpGet("pendientes")]
    public async Task<IActionResult> FacturasParaAsociar([FromQuery] FacturasFilter filter, [FromQuery] Pagination pagination, FacturasParaAsociarHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<FacturaListItem>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }
}
