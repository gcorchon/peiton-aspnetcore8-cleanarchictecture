using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Extensions;
using Peiton.Contracts.CNAEs;
using Peiton.Contracts.Common;
using Peiton.Core.UseCases.CNAEs;


namespace Peiton.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CNAEsController : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> CNAEsAsync([FromQuery] ObtenerCNAEsFilter filter, [FromQuery] Pagination pagination, CNAEsHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        return this.PaginatedResult(data.Items, data.Total);
    }

    [HttpPatch("{cnae}")]
    public async Task<IActionResult> ActualizarCNAEAsync(string cnae, [FromBody] ActualizarCNAERequest request, ActualizarCNAEHandler handler)
    {
        await handler.HandleAsync(cnae, request);
        return Accepted();
    }

}

