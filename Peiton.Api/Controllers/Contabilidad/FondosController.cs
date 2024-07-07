using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Contracts.Enums;
using Peiton.Core.UseCases.Partidas;

namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class FondosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> FondosAsync([FromQuery] FondosFilter filter, [FromQuery] Pagination pagination, [FromQuery] TipoFondo tipoFondo, FondosHandler handler)
    {
        var data = await handler.HandleAsync(filter, tipoFondo, pagination);

        var viewModel = mapper.Map<IEnumerable<FondoListItem>>(data.Items);
        var diferencia = data.Extra!["Diferencia"].ToString();
        return this.PaginatedResult(viewModel, new Dictionary<string, string> { { "X-Total-Count", data.Total.ToString() }, { "X-Diferencia", diferencia! } });
    }
}


