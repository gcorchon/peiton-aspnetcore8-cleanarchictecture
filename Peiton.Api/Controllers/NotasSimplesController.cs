using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Extensions;
using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.UseCases.NotasSimples;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotasSimplesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> NotasSimplesVentaAsync([FromQuery] NotasSimplesFilter filter, [FromQuery] Pagination pagination, NotasSimplesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<NotaSimpleListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }


    [HttpPatch("{id:int}")]
    public async Task<IActionResult> FinalizarNotaSimpleAsync(int id, FinalizarNotaSimpleHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

}