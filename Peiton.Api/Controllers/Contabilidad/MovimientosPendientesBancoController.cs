using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Core.Exceptions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.MovimientosPendientesBanco;
using Peiton.Core.UseCases.Contabilidad.MovimientosPendientesBanco;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;
using Peiton.Contracts.Asientos;

namespace Peiton.Api.Contabilidad;

[Route("api/[controller]")]
[ApiController]
[PeitonAuthorization(PeitonPermission.ContabilidadNuevosMovimientosMovimientosPendientesBanco)]
public class MovimientosPendientesBancoController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> MovimientosPendientesBanco([FromQuery] MovimientosPendientesBancoFilter filter, [FromQuery] Pagination pagination, MovimientosPendientesBancoHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<MovimientoPendienteBancoListItem>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> MovimientoPendienteBanco(int id, EntityHandler<AccountTransactionCP> handler)
    {
        try
        {
            var entity = await handler.HandleAsync(id);
            var vm = mapper.Map<MovimientoPendienteBancoViewModel>(entity);
            return Ok(vm);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost("{id:int}/asientos")]
    public async Task<IActionResult> Contabilizar(int id, [FromBody] AsientoSaveRequest[] request, ContabilizarHandler handler)
    {
        try
        {
            await handler.HandleAsync(id, request);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

    }
}
