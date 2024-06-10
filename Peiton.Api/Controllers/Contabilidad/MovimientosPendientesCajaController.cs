using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.MovimientosPendientesCaja;
using Peiton.Core.UseCases.Contabilidad.MovimientosPendientesCaja;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;
using Peiton.Contracts.Asientos;

namespace Peiton.Api.Contabilidad;

[Route("api/[controller]")]
[ApiController]
[PeitonAuthorization(PeitonPermission.Contapeiton)]
public class MovimientosPendientesCajaController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> MovimientosPendientesCaja([FromQuery] MovimientosPendientesCajaFilter filter, [FromQuery] Pagination pagination, MovimientosPendientesCajaHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<MovimientoPendienteCajaListItem>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> MovimientoPendienteCaja(int id, EntityHandler<CajaAMTA> handler)
    {
        var entity = await handler.HandleAsync(id);
        var vm = mapper.Map<MovimientoPendienteCajaViewModel>(entity);
        return Ok(vm);
    }

    [HttpPost("{id:int}/asientos")]
    public async Task<IActionResult> Contabilizar(int id, [FromBody] AsientoSaveRequest[] request, ContabilizarHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Ok();
    }
}
