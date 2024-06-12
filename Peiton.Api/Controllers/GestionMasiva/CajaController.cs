using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.Enums;
using Peiton.Core.UseCases.GestionMasiva.CajaMasiva;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[Route("api/[controller]")]
public class CajaController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> Caja([FromQuery] CajaFilter filter, [FromQuery] Pagination pagination, TipoMovimiento metodo, CajaHandler handler)
    {
        var data = await handler.HandleAsync(metodo, filter, pagination);
        var vm = mapper.Map<IEnumerable<CajaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

}
