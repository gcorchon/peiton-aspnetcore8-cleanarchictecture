using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.EmergenciasCentros;
using Peiton.Core.UseCases.EmergenciasCentros;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/emergencias-centros")]
public class EmergenciasCentrosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> EmergenciasAsync([FromQuery][Required] int tuteladoId, [FromQuery] EmergenciasCentrosFilter filter, [FromQuery] Pagination pagination, EmergenciasCentrosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, filter, pagination);
        var vm = mapper.Map<IEnumerable<EmergenciaCentroListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}/lista-comprobacion")]
    public async Task<IActionResult> CheckListsAsync(int id, ListaComprobacionHandler handler)
    {
        var vm = await handler.HandleAsync(id);
        return Ok(vm);
    }

    [HttpPatch("{id:int}/lista-comprobacion")]
    public async Task<IActionResult> GuardarCheckListsAsync(int id, [FromBody] CheckListItem[] request, GuardarListaComprobacionHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }
}