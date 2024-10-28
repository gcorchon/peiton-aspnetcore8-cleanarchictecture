using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Ausencias;
using Peiton.Contracts.Ausencias;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.InstitucionalAusencias)]
[Route("api/[controller]")]
public class AusenciasController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> AusenciasAsync([FromQuery] AusenciasFilter filter, [FromQuery] Pagination pagination, AusenciasHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<AusenciaViewModel>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerAusenciaAsync(int id, EntityHandler<Ausencia> handler)
    {
        var entity = await handler.HandleAsync(id);
        var vm = mapper.Map<AusenciaViewModel>(entity);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> AusenciaCreateAsync(GuardarAusenciaRequest data, CrearEntityHandler<Ausencia> handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> AusenciaUpdateAsync(int id, [FromBody] GuardarAusenciaRequest data, ActualizarEntityHandler<Ausencia> handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> AusenciaDeleteAsync(int id, DeleteEntityHandler<Ausencia> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}
