using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Core.UseCases.Contabilidad.Fondos;

namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
[Route("api/[controller]")]
public class FondosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Fondo([FromQuery] FondosFilter filter, [FromQuery] Pagination pagination, FondosHandler handler)
    {
        var data = await handler.HandleAsync(filter, [new CapituloPartidaFilter { Capitulo="8", Partida = "83192" },
                                                      new CapituloPartidaFilter { Capitulo="8", Partida = "83190" }
        ], pagination);

        var viewModel = mapper.Map<IEnumerable<FondoListItem>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }


}
