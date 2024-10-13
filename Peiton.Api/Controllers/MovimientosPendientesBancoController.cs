using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.MovimientosPendientesBanco;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;
using Peiton.Contracts.Asientos;
using Peiton.Core.UseCases.AccountTransactionsCP;

namespace Peiton.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[PeitonAuthorization(PeitonPermission.ContabilidadNuevosMovimientosMovimientosPendientesBanco)]
public class MovimientosPendientesBancoController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> MovimientosPendientesBancoAsync([FromQuery] MovimientosPendientesBancoFilter filter, [FromQuery] Pagination pagination, MovimientosPendientesBancoHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<MovimientoPendienteBancoListItem>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> MovimientoPendienteBancoAsync(int id, EntityHandler<AccountTransactionCP> handler)
    {
        var entity = await handler.HandleAsync(id);
        var vm = mapper.Map<MovimientoPendienteBancoViewModel>(entity);
        return Ok(vm);
    }

    [HttpPost("{id:int}/asientos")]
    public async Task<IActionResult> ContabilizarAsync(int id, [FromBody] AsientoSaveRequest[] request, ContabilizarMovimientoPendienteBancoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Ok();
    }
}
