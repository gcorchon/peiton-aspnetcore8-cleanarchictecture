using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.UseCases.Cajas;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[Route("api/[controller]")]
public class IncidenciaController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> IncidenciasAsync([FromQuery] IncidenciasFilter filter, [FromQuery] Pagination pagination, IncidenciasHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<IncidenciaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> IncidenciaAsync(int id, IncidenciaHandler handler)
    {
        var vm = await handler.HandleAsync(id);
        return Ok(vm);
    }

}