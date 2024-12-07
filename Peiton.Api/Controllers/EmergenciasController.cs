using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Emergencias;
using Peiton.Core.UseCases.Emergencias;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmergenciasController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> EmergenciasAsync([FromQuery][Required] int tuteladoId, [FromQuery] EmergenciasFilter filter, [FromQuery] Pagination pagination, EmergenciasHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, filter, pagination);
        var vm = mapper.Map<IEnumerable<EmergenciaListItem>>(data.Items);
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