using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Caja;
using Peiton.Contracts.Common;
using Peiton.Core.UseCases.CajasAMTA;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
[Route("api/[controller]")]
public class CajaAMTAController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> CajaAsync([FromQuery] CajaAMTAFilter filter, [FromQuery] Pagination pagination, CajaAMTAHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<CajaAMTAListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpDelete("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCajaBorrarCajaAMTA)]
    public async Task<IActionResult> EliminarMovimientoCajaAMTAAsync(int id, EliminarMovimientoCajaAMTAHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPost]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> GuardarMovimientoCajaAMTAAsync(GuardarCajaAMTA request, GuardarMovimientoCajaAMTAHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPost("documento")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaCaja)]
    public async Task<IActionResult> GenerarDocumentoCajaAMTAAsync(GuardarCajaAMTA request, GenerarDocumentoCajaAMTAHandler handler)
    {
        await handler.HandleAsync(request);
        //Aquí falta coger la respuesta del handler, que probablemente sea un Byte[] y devolverla como archivo
        return Ok();
    }

}
